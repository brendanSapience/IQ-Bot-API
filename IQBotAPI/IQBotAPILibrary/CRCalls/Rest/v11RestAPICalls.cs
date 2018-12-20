using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.CRCalls.Rest
{
    public class v11RestAPICalls
    {
        CRConnectionBroker broker;
        public v11RestAPICalls(CRConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String getTaskBots()
        {
            String body = "{\"sort\":[{\"field\":\"directory\",\"direction\":\"desc\"},{\"field\":\"name\",\"direction\":\"asc\"}],\"filter\":{},\"fields\":[],\"page\":{\"offset\":0,\"total\":2,\"totalFilter\":2,\"length\":200}}";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/v1/repository/directories/7/files/list";
            RestResponse MyResp = CRRestUtils.SendPostRequest(Req, body, this.broker.RestAuthToken,11);
            return MyResp.RetResponse;
        }
    }

}
