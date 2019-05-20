using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQBotAPILibrary;
using IQBotAPILibrary.CRCalls.Rest;
using IQBotAPILibrary.IQBotCalls.Rest;
using IQBotAPILibrary.DoctoolsCalls;
using IQBot_Calls;
using Doctools_Calls;
using CommandLine;
using ConsoleAppTests;

namespace IQBotUtilities
{
    class RunMe
    {
        static void Main(string[] args)
        {
            Boolean TestMode = true;

            if (TestMode)
            {
                TestSet.Run();
            }
            else
            {
                // --deletedomain "My Domain Name"
                Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           Console.WriteLine($"Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example!");
                       }
                   });
                Console.ReadKey();
            }

        }

        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }
    }
}
