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

        // LI Stats
        // http://localhost:81/IQBot/api/reporting/projects/c720a03e-fbbb-4dcb-9f49-471170fa04a1/totals
        // http://localhost:81/IQBot/api/project-fields


        // Output is CSV or JSON
        public String GetLearningInstanceStatistics(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/reporting/projects/"+ LearningInstanceID + "/totals";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceStats.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceStats.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceStats.Data LIData = r.data;

            Resp = "Accuracy,TotalFilesProcessed,TotalSTP,TotalFilesUploaded,TotalFilesToValidation,TotalFilesValidated,TotalFilesUnprocessable,TotalStagingPageCount,TotalProdPageCount"+ "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {
                
                int accuracy = LIData.totalAccuracy;
                int totalFilesProcessed = LIData.totalFilesProcessed;
                int totalSTP = LIData.totalSTP;
                int totalFilesUploaded = LIData.totalFilesUploaded;
                int totalFilesToValidation = LIData.totalFilesToValidation;
                int totalFilesValidated = LIData.totalFilesValidated;
                int totalFilesUnprocessable = LIData.totalFilesUnprocessable;
                int totalStagingPageCount = LIData.totalStagingPageCount;
                int totalProductionPageCount = LIData.totalProductionPageCount;
                Resp = Resp + accuracy + "," + totalFilesProcessed + "," + totalSTP +"," + totalFilesUploaded + "," + totalFilesToValidation +
                    "," + totalFilesValidated + "," + totalFilesUnprocessable + "," + totalStagingPageCount + "," + totalProductionPageCount + "\n";
            }


            return Resp;
        }

        // Output is CSV or JSON
        public String GetAllLearningInstances(Boolean RespInJsonFormat)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken,this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstancesList.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstancesList.Response>(MyResp.RetResponse);
            List< JsonObjects.LearningInstancesList.Datum> myList = r.data;
            

            if (RespInJsonFormat) { Resp = MyResp.RetResponse;}
            else
            {
                foreach (var item in myList)
                {
                    Resp = Resp + item.id + "," + item.name + "\n";
                }
            }


            return Resp;
        }

        public String GetLiNameFromLiID(String LiID, Boolean RespInJsonFormat)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects";
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
            if (RespInJsonFormat)
            {
                return "{\"LIName\":\"" + LiName + "\"}"; ;
            }
            else
            {
                return LiName  ;
            }
            
        }

        public String GetLiIDFromLiName(String LiName, Boolean RespInJsonFormat)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects";
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
            if (RespInJsonFormat)
            {
                return "{\"LiID\":\"" + LiID + "\"}";
            }
            else
            {
                return LiID;
            }
            
        }

        public String GetAllGroupsFromLIID(String LIID, Boolean RespInJsonFormat)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/"+LIID+"/categories?offset=0&limit=500&sort=-index";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            String RESPONSE = "";

            if (RespInJsonFormat) { RESPONSE = MyResp.RetResponse; }
            else
            {
                JsonObjects.GroupsList.Response r = JsonConvert.DeserializeObject<JsonObjects.GroupsList.Response>(MyResp.RetResponse);

                List<JsonObjects.GroupsList.Category> myList = r.data.categories;
                

                String GroupID;
                String GroupName;
                String GroupInternalID;
                String GroupState;
                Boolean GroupIsRunning;
                String GroupLastModifiedByUser;
                String GroupLastModifiedTimeStamp;
                int GroupFileCount;

                String AllRows = "";

                foreach (var item in myList)
                {
                    var AttrList = new List<string>();
                    GroupID = item.id; AttrList.Add(GroupID);
                    GroupName = item.name;AttrList.Add(GroupName);
                    GroupInternalID = item.visionBot.id;AttrList.Add(GroupInternalID);
                    GroupState = item.visionBot.currentState;AttrList.Add(GroupState);
                    GroupIsRunning = item.visionBot.running; AttrList.Add(GroupIsRunning.ToString());
                    GroupLastModifiedByUser = item.visionBot.lastModifiedByUser; AttrList.Add(GroupLastModifiedByUser);
                    GroupLastModifiedTimeStamp = item.visionBot.lastModifiedTimestamp; AttrList.Add(GroupLastModifiedTimeStamp);
                    GroupFileCount = item.fileCount;AttrList.Add(GroupFileCount.ToString());
                    String OneRow = JsonUtils.getCSVStringFromArray(AttrList,",");
                    AllRows = AllRows + OneRow + "\n";
                    //Console.WriteLine(item.name + ":" + item.id);
                }
                RESPONSE = AllRows;
            }
            
            return RESPONSE;
        }

        public String GetAllGroupsFromLIName(String LiName, Boolean RespInJsonFormat)
        {
            String s = GetLiIDFromLiName(LiName,false);
            if (s == "")
            {
                return "";
            }
            return GetAllGroupsFromLIID(s,RespInJsonFormat);
        }
    }
}
