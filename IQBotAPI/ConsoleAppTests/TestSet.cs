using Doctools_Calls;
using IQBot_Calls;
using IQBotAPILibrary;
using IQBotAPILibrary.IQBotCalls.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTests
{
    class TestSet
    {
        public static void Run()
        {


            Console.WriteLine("Initiating Broker.");

            String resp = "";

            resp = _v100.SplitPdfsWithBlankPages("http://localhost", 11051, @"C:\Users\Administrator\Desktop\customers\CareFirst\Sample_Invoice_Combined_BlankPages.pdf", "English", @"C:\Users\Administrator\Desktop\customers\CareFirst\Temp",true);
            //resp = _v100.SplitPdfsWithBlankPages("http://localhost", 11051, @"C:\Users\Administrator\Desktop\customers\CareFirst\Sample_Invoice_Combined_BlankPages.pdf", "English");
            Console.WriteLine("DEBUG Resp:" + resp);
            Console.ReadKey();

           // resp = _v100.SplitPdf("http://localhost", 11051, @"C:\Users\Administrator\Desktop\customers\CareFirst\Sample_Invoice_Combined_BlankPages.pdf", "1-2");
           // Console.WriteLine("DEBUG Resp:" + resp);
          //  Console.ReadKey();

            resp = _v100.MRPdfToText("http://localhost", 11051, @"C:\Users\Administrator\Desktop\Doctools\input-01_ML.pdf", "2");
            Console.WriteLine("DEBUG Resp:" + resp);
            Console.ReadKey();

            resp = _v100.OCRPdf("http://localhost", 11051, @"C:\Users\Administrator\Desktop\Doctools\input-01.pdf", "english");
            Console.WriteLine("DEBUG Resp:" + resp);
            Console.ReadKey();

            string Token = _v650._GetAuthorizationToken("http://localhost", 81, @"iqbot2", @"Un1ver$e", false);
            Console.WriteLine("Token:" + Token);


            resp = _v650.GetGroupLayoutInfo("http://localhost", 81, Token, false, "388965b7-2e35-4b1d-a35b-17c8f00e0320", 8, false);
            Console.WriteLine(resp);
            Console.ReadKey();

            resp = _v650.GetLearningInstanceFileList("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);
            Console.ReadKey();

            resp = _v650.GetLearningInstanceStatistics("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);
            Console.ReadKey();

            resp = _v650.GetFieldAccuracyStatistics("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);
            Console.ReadKey();

            resp = _v650.GetFieldClassificationStatistics("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);
            Console.ReadKey();

            resp = _v650.GetLearningInstances("http://localhost", 81, Token, false);

            resp = _v650.GetLearningInstanceNameFromID("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);

            resp = _v650.GetLearningInstanceIDFromName("http://localhost", 81, Token, false, "_ Learning Instance for Invoices - ML");
            Console.WriteLine(resp);

            resp = _v650.GetGroupsFromLearningInstanceID("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);

            resp = _v650.GetGroupsFromLearningInstanceName("http://localhost", 81, Token, false, "_ Learning Instance for Invoices - ML");
            Console.WriteLine(resp);

            resp = _v650.GetValidationQueueSummary("http://localhost", 81, Token, false, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);

            resp = _v650.GetLearningInstanceValidationQueueCurrentCount("http://localhost", 81, Token, true, "969e6d85-744f-4aef-98da-c7c996e4f4f4");
            Console.WriteLine(resp);

            Console.ReadKey();
            // initiate the broker
            //IQBotConnectionBroker broker = new IQBotConnectionBroker("localhost",1434,"aaadmin","Un1ver$e123");
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, "http://localhost", 81, @"iqbot2", @"Un1ver$e", 9996);
            //Console.ReadKey();
            //CRConnectionBroker crbroker = new CRConnectionBroker(11, "http://localhost", 8080, @"iqbot1", @"Un1ver$e123");

            //v11RestAPICalls apicallsCR = new v11RestAPICalls(crbroker);
            //resp = apicallsCR.getTaskBots();

            // initiate the apicalls library
            // _530ReadDBAPICalls apicallsR = new IQBotAPILibrary._530ReadDBAPICalls(broker);
            //_530WriteDBAPICalls apicallsW = new IQBotAPILibrary._530WriteDBAPICalls(broker);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);



            // submit READ api calls

            //resp = apicallsR.GetLIFiles("8c554e14-8e1f-437e-aeec-8f363627eb6f");
            //resp = apicallsR.GetLIDetails("8c554e14-8e1f-437e-aeec-8f363627eb6f");
            //resp = apicallsR.GetFileDetails("000ee6f5-0385-42a9-9101-a3c29f2618ca");
            //resp = apicallsR.GetClassificationReport("bdf725ea-e2ba-4ee8-99e6-37ff8f67d86e");
            //resp = apicallsR.GetCustomFields("54bffd90-f0ae-4b73-aec5-38ecbb1ec384");
            //resp = apicallsR.GetInvalidFiles();
            //resp = apicallsR.GetExportImportActivities();
            //resp = apicallsR.GetListOfCorrectedValues();
            //resp = apicallsR.GetListOfDomains();
            //resp = apicallsR.GetListOfLanguages();
            //resp = apicallsR.GetGroupFromFilename("1001748643.pdf");

            // submit WRITE api calls
            //apicallsW.SetLearningInstanceName("01bc3faa-191f-4921-a3fc-5f71c60d723e", "Test123");




            Console.ReadKey();

        }
    

    }
}
