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

        public static String SplitPdf(String DTUrl, int DTPort, String InputFilePath, String Range)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.SplitPdf(InputFilePath, InputFilePath, Range);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
            //return "";
        }


        public static String OCRPdf(String DTUrl, int DTPort, String InputFilePath, String OutputFilePath, String Language)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, OutputFilePath, Language);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
            //return "";
        }

        public static String OCRPdf(String DTUrl, int DTPort, String InputFilePath, String Language)
        {
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, InputFilePath, Language);
            HttpStatusCode code = Resp.StatusCode;
            return code.ToString();
            //return "";
        }

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

            //IQBotAPILibrary.JsonObjects.Doctools.PDFToText.Response r = JsonConvert.DeserializeObject<IQBotAPILibrary.JsonObjects.Doctools.PDFToText.Response>(responseString);

            HttpStatusCode code = Resp.StatusCode;
            return responseString;
            //return "";
        }

        public static String SplitPdfsWithBlankPages(String DTUrl, int DTPort, String InputFilePath, String Language)
        {
            String Output = "";
            DoctoolsConnectionBroker rbroker = new DoctoolsConnectionBroker(DTUrl, DTPort);
            _100DTRestCalls apicallsRest = new _100DTRestCalls(rbroker);

            String RootPath = Path.GetDirectoryName(InputFilePath) + "\\";

            String TempMRFile = RootPath + Path.GetFileNameWithoutExtension(InputFilePath) + "_MR" + Path.GetExtension(InputFilePath);

            Output = Output + "Machine Readable Filename: " + TempMRFile + "\n";
            HttpWebResponse Resp = apicallsRest.ConvertPDFToMachineReadable(InputFilePath, TempMRFile, Language);
            HttpStatusCode code = Resp.StatusCode;

            Output = Output + "MR Call Response: " + code + "\n";

            // TO DO check for response status

            HttpWebResponse Resp1 = apicallsRest.GetTextInMachineReadablePDF(TempMRFile, "2");
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

            List<int> TempList = new List<int>();
            int PreviousEl = 0;
            //Console.WriteLine("Size:" + r.children.Count);

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

                        SplitPdf(DTUrl, DTPort,InputFilePath, Range);
                    }

                }else if(NumberOfItemsOnPage == 0)
                {
                    // Show TempList
                    // Reset TempList
                    //Console.WriteLine("Debug: Break Detected, Range: ["+string.Join(",",TempList.ToArray())+"]");
                    String Range = TempList[0] + "-" + TempList[TempList.Count - 1];
                    //Console.WriteLine("Debug - Range: [" + Range + "]");
                    Output = Output + "Range Identified: " + Range + "\n";
                    SplitPdf(DTUrl, DTPort,InputFilePath, Range);

                    TempList.Clear();
                    PreviousEl = CurrentPage;
                }

            }
            return Output;
        }
    }
}
