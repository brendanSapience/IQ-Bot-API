using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQBotAPILibrary;
using IQBotAPILibrary.CRCalls.Rest;

namespace ConsoleAppTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Broker.");

            String resp = "";
            // initiate the broker
            //IQBotConnectionBroker broker = new IQBotConnectionBroker("localhost",1434,"aaadmin","Un1ver$e123");
            //IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6,"http://localhost", 3000,8080, @"iqbot1", @"Un1ver$e123",9996);

            CRConnectionBroker crbroker = new CRConnectionBroker(11, "http://localhost", 8080, @"iqbot1", @"Un1ver$e123");

            v11RestAPICalls apicallsCR = new v11RestAPICalls(crbroker);
            resp = apicallsCR.getTaskBots();

            // initiate the apicalls library
           // _530ReadDBAPICalls apicallsR = new IQBotAPILibrary._530ReadDBAPICalls(broker);
            //_530WriteDBAPICalls apicallsW = new IQBotAPILibrary._530WriteDBAPICalls(broker);
           // _530ReadRestAPICalls apicallsRest = new _530ReadRestAPICalls(rbroker);

            // submit Rest api calls
            //resp = apicallsRest.GetAllLearningInstances();

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


            Console.WriteLine("Response:"+ resp);

            Console.ReadKey();

        }
    }
}
