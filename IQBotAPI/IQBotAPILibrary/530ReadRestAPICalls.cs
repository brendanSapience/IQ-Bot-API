using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary
{
    public class _530ReadRestAPICalls
    {
        ConnectionBroker broker;
        public _530ReadRestAPICalls(ConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String GetAllLearningInstances()
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/api/projects";
            String MyResp = RestUtils.SendGetRequest(Req,this.broker.RestAuthToken);
            return MyResp;
        }
    }
}
