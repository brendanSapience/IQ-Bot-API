using IQBotAPILibrary.IQBotCalls.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.IQBotCalls.Rest
{


    public class _600ReadRestAPICalls
    {
        IQBotConnectionBroker broker;
        public _600ReadRestAPICalls(IQBotConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String GetAllLearningInstances()
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/IQBot/api/projects";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken,this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstancesList.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstancesList.Response>(MyResp.RetResponse);
            List< JsonObjects.LearningInstancesList.Datum> myList = r.data;
            foreach (var item in myList)
            {
                Console.WriteLine("Test:"+item.id+":"+item.name);
                //item.name;
            }

            return MyResp.RetResponse;
        }

        public String GetLiNameFromLiID(String LiID)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/IQBot/api/projects";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstancesList.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstancesList.Response>(MyResp.RetResponse);
            List<JsonObjects.LearningInstancesList.Datum> myList = r.data;
            Boolean Found = false;
            String LiName = "";
            foreach (var item in myList)
            {
                if(item.id == LiID)
                {
                    Found = true;
                    LiName = item.name;
                }
                if (Found)
                {
                    break;
                }
                
                //item.name;
            }

            return "{\"LIName\":\"" + LiName + "\"}"; ;
        }

        public String GetLiIDFromLiName(String LiName)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/IQBot/api/projects";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstancesList.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstancesList.Response>(MyResp.RetResponse);
            List<JsonObjects.LearningInstancesList.Datum> myList = r.data;
            Boolean Found = false;
            String LiID = "";
            foreach (var item in myList)
            {
                if (item.name == LiName)
                {
                    Found = true;
                    LiID = item.id;
                }
                if (Found)
                {
                    break;
                }

                //item.name;
            }

            return "{\"LiID\":\"" + LiID + "\"}"; ;
        }

        public String GetAllGroupsFromLIID(String LIID)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/IQBot/api/projects/"+LIID+"/categories?offset=0&limit=50&sort=-index";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            return MyResp.RetResponse;
        }

        public class RootObject
        {
            public string LiID { get; set; }
        }

        public String GetAllGroupsFromLIName(String LiName)
        {
            String s = GetLiIDFromLiName(LiName);
            Console.WriteLine("DEBUG:" + s);
            RootObject r = JsonConvert.DeserializeObject<RootObject>(s);
            
            String Req = this.broker.RestEndpointURL + ":" + this.broker.CRPort + "/IQBot/api/projects/" + r.LiID + "/categories?offset=0&limit=50&sort=-index";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            return MyResp.RetResponse;
        }
    }
}
