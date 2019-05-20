using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IQBotAPILibrary.JsonObjects;
using Newtonsoft.Json;

namespace IQBotAPILibrary
{
    public class DoctoolsConnectionBroker
    {

        public String RestEndpointURL = "";
        public int RestEndpointPort = 11051;

        public DoctoolsConnectionBroker(String RestBaseURI, int RestAuthPort)
        {
            this.RestEndpointURL = RestBaseURI;
            this.RestEndpointPort = RestAuthPort;

            
        }

    }
}
