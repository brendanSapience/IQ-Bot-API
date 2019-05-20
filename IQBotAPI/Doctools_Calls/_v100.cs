using System;
using IQBotAPILibrary;
using IQBotAPILibrary.DoctoolsCalls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using static IQBotAPILibrary.JsonObjects.Doctools.PDFToText;

namespace Doctools_Calls
{
    public class _v100
    {
        // Split a PDF based on a range
        public static String SplitPdf(String DTUrl, int DTPort, String InputFilePath, String Range, String OutputFolder)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.SplitPdf(InputFilePath, OutputFolder, Range);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
            
        }

        // Generate a Machine Readable PDF from a Non MR Pdf File
        public static String OCRPdf(String DTUrl, int DTPort, String InputFilePath, String OutputFilePath, String Language)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, OutputFilePath, Language);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
            
        }

        // Generate a Machine Readable PDF from a Non MR Pdf File
        public static String OCRPdf(String DTUrl, int DTPort, String InputFilePath, String Language)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, InputFilePath, Language);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
        }

        // Returns a JSON response containing the content of the OCR'ed file and location information for each field extracted
        public static String MRPdfToText(String DTUrl, int DTPort, String InputFilePath, String Depth)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.GetTextInMachineReadablePDF(InputFilePath, Depth);
            String responseString = "";
            using (Stream stream = Resp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            HttpStatusCode code = Resp.StatusCode;
            return responseString;
        }

        public static String SplitPdfsWithBlankPages(String DTUrl, int DTPort, String InputFilePath, String Language)
        {
            return SplitPdfsWithBlankPages(DTUrl, DTPort, InputFilePath, Language, "", false);
        }
        // Split a PDF into multiple PDFs (on blank pages)
        public static String SplitPdfsWithBlankPages(String DTUrl, int DTPort, String InputFilePath, String Language, String OutputFolder, Boolean DeleteTempFiles)
        {
            String DEPTH = "2";
            // TO DO: add option to remove temp MR file
            // TODO: add option to automatically generate files in another folder

            String Output = "";
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);

            String OutputRootPath = Path.GetDirectoryName(InputFilePath) + "\\";

            String TempMRFile = "";

            if (OutputFolder != null && OutputFolder != "")
            {
                OutputRootPath = OutputFolder;
            }
       
            TempMRFile = OutputRootPath + Path.GetFileNameWithoutExtension(InputFilePath) + "_MR" + Path.GetExtension(InputFilePath);

            Output = Output + "Machine Readable Filename: " + TempMRFile + "\n";
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, TempMRFile, Language);
            HttpStatusCode code = Resp.StatusCode;

            Output = Output + "MR Call Response: " + code + "\n";

            // TO DO check for response status

            HttpWebResponse Resp1 = apicallsRest.GetTextInMachineReadablePDF(TempMRFile, DEPTH);
            String responseString1 = "";
            using (Stream stream = Resp1.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                responseString1 = reader.ReadToEnd();
            }
            HttpStatusCode code1 = Resp1.StatusCode;
            Output = Output + "Pdf To Text Call Response: " + code1 + "\n";

            IQBotAPILibrary.JsonObjects.Doctools.PDFToText.Response r = JsonConvert.DeserializeObject<IQBotAPILibrary.JsonObjects.Doctools.PDFToText.Response>(responseString1);

            Output = Output + "Response Successfully Parsed"+ "\n";
            if (DeleteTempFiles){File.Delete(TempMRFile);}
            List<int> TempList = new List<int>();
            int PreviousEl = 0;

            Child last = r.children.Last();

            foreach (var item in r.children)
            {
                int CurrentPage = item.pageNumber;
                int NumberOfItemsOnPage = item.children.Count;
                //Console.WriteLine("DEBUG: Current Page:" + CurrentPage);
                if(NumberOfItemsOnPage > 0)
                {
                    if(item != last)
                    {
                       // Console.WriteLine("Debug: " + NumberOfItemsOnPage + " Items Found on page:" + CurrentPage);
                        TempList.Add(CurrentPage);
                        PreviousEl = CurrentPage;
                    }
                    else // not empty, but last element
                    {
                        TempList.Add(CurrentPage);
                        //Console.WriteLine("Debug: Break Detected, Range: [" + string.Join(",", TempList.ToArray()) + "]");
                        String Range = TempList[0] + "-" + TempList[TempList.Count - 1];
                        //Console.WriteLine("Debug - Range: [" + Range+"]");
                        Output = Output + "Range Identified: " + Range + "\n";

                        SplitPdf(DTUrl, DTPort,InputFilePath, Range, OutputRootPath);
                    }

                }else if(NumberOfItemsOnPage == 0)
                {
                    // Show TempList
                    // Reset TempList
                    //Console.WriteLine("Debug: Break Detected, Range: ["+string.Join(",",TempList.ToArray())+"]");
                    String Range = TempList[0] + "-" + TempList[TempList.Count - 1];
                    //Console.WriteLine("Debug - Range: [" + Range + "]");
                    Output = Output + "Range Identified: " + Range + "\n";
                    SplitPdf(DTUrl, DTPort,InputFilePath, Range, OutputRootPath);

                    TempList.Clear();
                    PreviousEl = CurrentPage;
                }

            }
            return Output;
        }
    }
}
