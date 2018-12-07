using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQBotAPILibrary;

namespace ConsoleAppTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Broker.");
            ConnectionBroker broker = new ConnectionBroker("localhost",1434,"aaadmin","Un1ver$e123");
            broker.initiateSQLConnection();
            DBAPICalls apicalls = new IQBotAPILibrary.DBAPICalls(broker);

            //String resp = apicalls.GetIQBotConfiguration();

            String resp = apicalls.GetIQBotLearningInstances();

            Console.WriteLine("Response:"+ resp);
            //broker.runQuery("Configurations", "select * from CognitivePlatformNodes");



            Console.ReadKey();

        }
    }
}
