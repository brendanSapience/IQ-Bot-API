using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.DoctoolsCalls
{
    public class _100DTRestCalls
    {
        DoctoolsConnectionBroker broker;
        public _100DTRestCalls(DoctoolsConnectionBroker b)
        {
            this.broker = b;
        }

        public HttpWebResponse SplitPdf(String InputFilePath, String OutputFilePath, String Range)
        {

            String url = this.broker.RestEndpointURL + ":" + this.broker.RestEndpointPort + "/pdf/split";

            string CT0 = "file";
            string fullPath0 = InputFilePath; // @"C:\Users\Administrator\Desktop\Doctools\input-01.pdf";
            FormUpload.FileParameter f0 = new FormUpload.FileParameter(File.ReadAllBytes(fullPath0), Path.GetFileName(InputFilePath), "multipart/form-data");

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add(CT0, f0);
            d.Add("range", Range);

            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            HttpWebResponse Resp = FormUpload.MultipartFormDataPost(url, ua, d);

            String GeneratedFileName = "";
            //Console.WriteLine("DEBUG:" + InputFilePath + "|" + OutputFilePath);
            //C:\Users\Administrator\Desktop\customers\CareFirst\Sample_Invoice_Combined_BlankPages.pdf|C:\Users\Administrator\Desktop\customers\CareFirst\Temp
            if (InputFilePath == OutputFilePath)
            {
                String RootPath = Path.GetDirectoryName(OutputFilePath) + "\\";
                String FileNameWithoutExt = Path.GetFileNameWithoutExtension(OutputFilePath);
                String FileExtension = Path.GetExtension(OutputFilePath);
                GeneratedFileName = RootPath + FileNameWithoutExt + "_" + Range + FileExtension;
            }
            else
            {
                String RootPath = OutputFilePath + "\\";
                String FileNameWithoutExt = Path.GetFileNameWithoutExtension(InputFilePath);
                String FileExtension = Path.GetExtension(InputFilePath);
                GeneratedFileName = RootPath + FileNameWithoutExt + "_" + Range + FileExtension;

            }

            //Console.WriteLine("Debug:" + GeneratedFileName);
            using (Stream output = File.OpenWrite(GeneratedFileName))
            using (Stream input = Resp.GetResponseStream())
            {
                input.CopyTo(output);
            }


            return Resp;
        }

        // Transform an image PDF into a machine readable PDF
        //String PathToPdf, String OCRLanguage, String PathToJsonFile
        public HttpWebResponse ConvertPDFToMachineReadable(String InputFilePath, String OutputFilePath, String Language)
        {
        
            String url = this.broker.RestEndpointURL + ":" + this.broker.RestEndpointPort + "/ocr/afr";

            string CT0 = "file";
            string fullPath0 = InputFilePath; 
            FormUpload.FileParameter f0 = new FormUpload.FileParameter(File.ReadAllBytes(fullPath0), Path.GetFileName(InputFilePath), "multipart/form-data");

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add(CT0, f0);
            d.Add("language", Language);

            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            HttpWebResponse Resp = FormUpload.MultipartFormDataPost(url, ua, d);

            String GeneratedFileName = "";
            if (InputFilePath == OutputFilePath)
            {
                String RootPath = Path.GetDirectoryName(OutputFilePath) + "\\";
                String FileNameWithoutExt = Path.GetFileNameWithoutExtension(OutputFilePath);
                String FileExtension = Path.GetExtension(OutputFilePath);
                GeneratedFileName = RootPath + FileNameWithoutExt + "_MR_"  + FileExtension;
            }
            else
            {
                GeneratedFileName = OutputFilePath;
            }

            using (Stream output = File.OpenWrite(OutputFilePath))
            using (Stream input = Resp.GetResponseStream())
            {
                input.CopyTo(output);
            }

            
            return Resp;
        }

        // [{  "x": 110,  "y": 710,  "width": 190,  "height": 22,  "backgroundColor": "#000000",  "opacity": 1,  "page": 1}]
        public HttpWebResponse AnnotatePdf(String InputFilePath, String OutputFilePath, String json)
        {

            String url = this.broker.RestEndpointURL + ":" + this.broker.RestEndpointPort + "/pdf/annotate";

            string CT0 = "file";
            string fullPath0 = InputFilePath;
            FormUpload.FileParameter f0 = new FormUpload.FileParameter(File.ReadAllBytes(fullPath0), Path.GetFileName(InputFilePath), "multipart/form-data");

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add(CT0, f0);

            d.Add("json", json);

            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            HttpWebResponse Resp = FormUpload.MultipartFormDataPost(url, ua, d);

            String GeneratedFileName = "";
            if (InputFilePath == OutputFilePath)
            {
                String RootPath = Path.GetDirectoryName(OutputFilePath) + "\\";
                String FileNameWithoutExt = Path.GetFileNameWithoutExtension(OutputFilePath);
                String FileExtension = Path.GetExtension(OutputFilePath);
                GeneratedFileName = RootPath + FileNameWithoutExt + "_MR_" + FileExtension;
            }
            else
            {
                GeneratedFileName = OutputFilePath;
            }

            using (Stream output = File.OpenWrite(OutputFilePath))
            using (Stream input = Resp.GetResponseStream())
            {
                input.CopyTo(output);
            }


            return Resp;
        }

        // Transform an image PDF into a machine readable PDF
        //String PathToPdf, String OCRLanguage, String PathToJsonFile
        public HttpWebResponse GetTextInMachineReadablePDF(String InputFilePath,String Depth)
        {

            String url = this.broker.RestEndpointURL + ":" + this.broker.RestEndpointPort + "/pdf/text";

            string CT0 = "file";
            string fullPath0 = InputFilePath; 
            FormUpload.FileParameter f0 = new FormUpload.FileParameter(File.ReadAllBytes(fullPath0), Path.GetFileName(InputFilePath), "multipart/form-data");

            Dictionary<string, object> d = new Dictionary<string, object>();

            d.Add(CT0, f0);
            d.Add("depth", Depth);

            string ua = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
            HttpWebResponse Resp = FormUpload.MultipartFormDataPost(url, ua, d);

            return Resp;
        }
    }
}
