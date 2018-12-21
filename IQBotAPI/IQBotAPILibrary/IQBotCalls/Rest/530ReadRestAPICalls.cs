using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary
{
    public class _530ReadRestAPICalls
    {
        IQBotConnectionBroker broker;
        public _530ReadRestAPICalls(IQBotConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String GetAllLearningInstances()
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/api/projects";
            RestResponse MyResp = RestUtils.SendGetRequest(Req,this.broker.RestAuthToken,this.broker.IQBotMajorVersion);

            return MyResp.RetResponse;
        }
    }
}
