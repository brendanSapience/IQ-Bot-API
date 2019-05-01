using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQBotAPILibrary;
using IQBotAPILibrary.CRCalls.Rest;
using IQBotAPILibrary.IQBotCalls.Rest;
using IQBot_Calls;

namespace ConsoleAppTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Broker.");

            String resp = "";

            string Token = _v650._GetAuthorizationToken("http://localhost", 81, @"iqbot2", @"Un1ver$e", false);
            Console.WriteLine("Token:" + Token);

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

            resp = _v650.GetLearningInstances("http://localhost", 81,Token, false);

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
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6,"http://localhost",81, @"iqbot2", @"Un1ver$e",9996);
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
