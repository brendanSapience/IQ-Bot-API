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

        //http://localhost:81/IQBot/api/projects/969e6d85-744f-4aef-98da-c7c996e4f4f4/detail-summary
        ///IQBot/api/projects/388965b7-2e35-4b1d-a35b-17c8f00e0320/categories/8/bots/Edit
        ///

        public String GetGroupLayout(Boolean RespInJsonFormat, String LearningInstanceID, int GroupNumber, Boolean ShowAllFields)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/categories/"+GroupNumber+"/bots/Edit";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            //Console.WriteLine("DEBUG :"+MyResp.RetResponse);
            JsonObjects.GroupDefinition.Response r = JsonConvert.DeserializeObject<JsonObjects.GroupDefinition.Response>(MyResp.RetResponse);
            List<JsonObjects.GroupDefinition.Field3> GrpData = r.visionBotData.DataModel.Fields; // contains the mapping between Field ID and Field Name
            List<JsonObjects.GroupDefinition.Field2> allFields = r.visionBotData.Layouts[0].Fields; // contains the coordinates of each field

            // the following 3 objects contain all SIR Data
            List<JsonObjects.GroupDefinition.Line> SirFields = r.visionBotData.Layouts[0].SirFields.Lines; // Definition of SIR Boxes (coordinates)
            List<JsonObjects.GroupDefinition.Region> SirRegions = r.visionBotData.Layouts[0].SirFields.Regions; // Each SIR Region in detail
            List<JsonObjects.GroupDefinition.Field> SirFields2 = r.visionBotData.Layouts[0].SirFields.Fields;   // Each SIR Field

            IDictionary<string, string> FieldIdFieldNameDict = new Dictionary<string, string>();
            
            foreach(JsonObjects.GroupDefinition.Field3 item in GrpData)
            {
                FieldIdFieldNameDict.Add(item.Id, item.Name);
            }

            //Console.WriteLine("DEBUGDict Size:" + FieldIdFieldNameDict.Count);
            // foreach(var g in FieldIdFieldNameDict)
            // {
            //     Console.WriteLine("DEBUG:" + g.Key+"|"+g.Value);
            // }
            if (!ShowAllFields)
            {
                Resp = "FieldName,Label,ValueBounds,Bounds" + "\n";
            }
            else
            {
                Resp = "FieldName,FieldId,Label,StartsWith,EndsWith,FormatExpression,DisplayValue,IsMultiline,Bounds,ValueBounds,FieldDirection,MergeRatio,SimilarityFactor," +
                    "FieldType,IsValueAutoBound,ValueType,IsDollarCurrency" + "\n";
            }
            

            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {
                foreach (JsonObjects.GroupDefinition.Field2 field in allFields)
                {
                   // Console.WriteLine("Loking for:" + field.FieldId);
                    String FieldName = FieldIdFieldNameDict[field.FieldId];
                    String FieldID = field.Id;
                    String FieldLabel = field.Label;
                    String StartsWith = field.StartsWith;
                    String EndsWith = field.EndsWith;
                    String FormatExpression = field.FormatExpression;
                    String FieldDisplayValue = field.DisplayValue;
                    Boolean IsMultiline = field.IsMultiline;
                    String FieldBounds = field.Bounds;
                    String FieldValueBounds = field.ValueBounds; 
                    int FieldDirection = field.FieldDirection;
                    int MergeRatio = field.MergeRatio;
                    double SimilarityFactor = field.SimilarityFactor;
                    int FieldType = field.Type;
                    Boolean IsValueBoundAuto = field.IsValueBoundAuto;
                    int ValueType = field.ValueType;
                    String IsDollarCurrency = field.IsDollarCurrency;

                    if (!ShowAllFields)
                    {
                        Resp = Resp + FieldName + ","+ FieldLabel + ",\"" + FieldValueBounds + "\",\"" + FieldBounds + "\"\n";
                    }
                    else
                    {
                        Resp = Resp + FieldName + "," + FieldID + "," + FieldLabel + "," + StartsWith + "," + EndsWith +
                            FormatExpression + "," + FieldDisplayValue + "," + IsMultiline + ",\"" + FieldValueBounds + "\",\"" + FieldValueBounds + "\","+
                            FieldDirection + "," + MergeRatio + "," + SimilarityFactor + "," + FieldType + "," + IsValueBoundAuto +
                            ValueType + "," + IsDollarCurrency +
                            "\n";
                    }
                    
                }

                
            }


            return Resp;


            return Resp;
        }

        public String GetLearningInstanceValidationQueueCurrentCount(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/detail-summary";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            //Console.WriteLine("DEBUG :"+MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceDetails.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Data LIData = r.data;

           // Resp = "InValidationQueue,ProdValidatedFiles" + "\n";
            if (RespInJsonFormat) {
                Resp = "{\"count\":"+ LIData.pendingForReview+"}";
            }
            else
            {

                int InValidationQueue = LIData.pendingForReview;
                //int ProdValidatedFiles = LIData.productionReviewFiles;



                Resp = Resp + InValidationQueue;
            }


            return Resp;
        }

        public String GetFileListFromLearningInstance(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/files";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            //Console.WriteLine("DEBUG :"+MyResp.RetResponse);
            JsonObjects.LearningInstanceFilesList.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceFilesList.Response>(MyResp.RetResponse);
            List<JsonObjects.LearningInstanceFilesList.Datum> LIData = r.data;

            Resp = "FileID,FileName,GroupID,IsProduction,FileSize,IsProcessed,Format" + "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {
                foreach (var item in LIData)
                {
                    Resp = Resp + item.fileId + "," + item.fileName + "," + item.classificationId + "," + item.isProduction + "," + item.fileSize + "," + item.processed + "," + item.format + "\n";
                }
            }


            return Resp;
        }

        public String GetLearningInstanceValidationSummary(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/detail-summary";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            //Console.WriteLine("DEBUG :"+MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceDetails.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Data LIData = r.data;

            Resp = "InValidationQueue,ProdValidatedFiles" + "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {

                int InValidationQueue = LIData.pendingForReview;
                int ProdValidatedFiles = LIData.productionReviewFiles;
                


                Resp = Resp + InValidationQueue + "," + ProdValidatedFiles + "\n";
            }


            return Resp;
        }

        public String GetLearningInstanceDetailsPROD(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/detail-summary";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceDetails.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceDetails.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Data LIData = r.data;

            Resp = "ProdPageCount,ProdProcessedFiles,ProdProcessedFilesPercentage,ProdAccuracy,ProdUnclassified," +
                "ProdSTP,ProdSuccessFiles,ProdTotalBots,ProdTotalFiles,ProdTotalGroups,ProdInvalid" + "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {

                int ProdPageCount = LIData.productionPageCount;
                int ProdProcessedFiles = LIData.productionProcessedFiles;
                int ProdProcessedFilesPercentage = LIData.productionProcessedFilesPercentage;
                int ProdAccuracy = LIData.productionAccuracy;
                int ProdUnclassified = LIData.productionDocumentsUnclassified;
                int ProdSTP = LIData.productionSTP;
                int ProdSuccessFiles = LIData.productionSuccessFiles;
                int ProdTotalBots = LIData.productionTotalBots;
                int ProdTotalFiles = LIData.productionTotalFiles;
                int ProdTotalGroups = LIData.productionTotalGroups;
                int ProdInvalid = LIData.productionInvalidFiles;

                Resp = Resp + ProdPageCount + "," + ProdProcessedFiles + "," + ProdProcessedFilesPercentage + "," + ProdAccuracy + "," + ProdUnclassified +
                    "," + ProdSTP + "," + ProdSuccessFiles + "," + ProdTotalBots + "," + ProdTotalFiles + "," + ProdTotalGroups + "," + ProdInvalid + "\n";
            }


            return Resp;
        }

        public String GetLearningInstanceDetailsSTAGING(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/" + LearningInstanceID + "/detail-summary";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceDetails.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceDetails.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceDetails.Data LIData = r.data;

            Resp = "StagingPageCount,StagingTestedFiles,StagingTestFilesPercentage,StagingAccuracy,StagingUnclassified," +
                "StagingSTP,StagingSucessFiles,StagingTotalBots,StagingTotalFiles,StagingTotalGroups,StagingFailed" + "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {

                int StagingPageCount = LIData.stagingPageCount;
                int StagingTestedFiles = LIData.stagingTestedFiles;
                int StagingTestFilesPercentage = LIData.stagingTestedFilesPercentage;
                int StagingAccuracy = LIData.stagingAccuracy;
                int StagingUnclassified = LIData.stagingDocumentsUnclassified;
                int StagingSTP = LIData.stagingSTP;
                int StagingSucessFiles = LIData.stagingSuccessFiles;
                int StagingTotalBots = LIData.stagingTotalBots;
                int StagingTotalFiles = LIData.stagingTotalFiles;
                int StagingTotalGroups = LIData.stagingTotalGroups;
                int StagingFailed = LIData.stagingFailedFiles;

                Resp = Resp + StagingPageCount + "," + StagingTestedFiles + "," + StagingTestFilesPercentage + "," + StagingAccuracy + "," + StagingUnclassified +
                    "," + StagingSTP + "," + StagingSucessFiles + "," + StagingTotalBots + "," + StagingTotalFiles + "," + StagingTotalGroups + "," + StagingFailed + "\n";
            }


            return Resp;
        }
        // Output is CSV or JSON
        public String GetLearningInstanceStatistics(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/reporting/projects/"+ LearningInstanceID + "/totals";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceStats.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceStats.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceStats.Data LIData = r.data;

            Resp ="Accuracy,TotalFilesProcessed,TotalSTP,TotalFilesUploaded,TotalFilesToValidation,TotalFilesValidated,TotalFilesUnprocessable,TotalStagingPageCount,TotalProdPageCount"+ "\n";
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
        public String GetLearningInstanceFieldAccuracyStatistics(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/reporting/projects/" + LearningInstanceID + "/totals";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceStats.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceStats.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceStats.Data LIData = r.data;

            Resp ="FieldName,FieldAccuracyPercent"+ "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {
                List<JsonObjects.LearningInstanceStats.FieldRepresentation> FieldRep = LIData.classification.fieldRepresentation;
                List<JsonObjects.LearningInstanceStats.Field> FieldAccuracy = LIData.accuracy.fields;

                foreach(JsonObjects.LearningInstanceStats.Field f in FieldAccuracy)
                {
                    String fName = f.name;
                    int fAccuracy = f.accuracyPercent;
                   
                    Resp = Resp + fName + "," + fAccuracy + "\n";
                }
            }
            return Resp;
        }

        // Output is CSV or JSON
        public String GetLearningInstanceFieldlCassificationStatistics(Boolean RespInJsonFormat, String LearningInstanceID)
        {
            String Resp = "";
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/reporting/projects/" + LearningInstanceID + "/totals";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            JsonObjects.LearningInstanceStats.Response r = JsonConvert.DeserializeObject<JsonObjects.LearningInstanceStats.Response>(MyResp.RetResponse);
            JsonObjects.LearningInstanceStats.Data LIData = r.data;

            Resp ="FieldName,RepresentationPercent" + "\n";
            if (RespInJsonFormat) { Resp = MyResp.RetResponse; }
            else
            {
                List<JsonObjects.LearningInstanceStats.FieldRepresentation> FieldRep = LIData.classification.fieldRepresentation;
                //List<JsonObjects.LearningInstanceStats.Field> FieldAccuracy = LIData.accuracy.fields;

                foreach (JsonObjects.LearningInstanceStats.FieldRepresentation f in FieldRep)
                {
                    String fName = f.name;
                    int fRepPercent = f.representationPercent;

                    Resp = Resp + fName + "," + fRepPercent + "\n";
                }
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

            Resp = "LearingInstanceID,LearningInstanceName" + "\n";

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

        public String GetLiNameFromLiID(Boolean RespInJsonFormat,String LiID)
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

        public String GetLiIDFromLiName(Boolean RespInJsonFormat,String LiName)
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

        public String GetAllGroupsFromLIID(Boolean RespInJsonFormat, String LIID)
        {
            String Req = this.broker.RestEndpointURL + ":" + this.broker.RestAuthEndpointPort + "/IQBot/api/projects/"+LIID+"/categories?offset=0&limit=500&sort=-index";
            RestResponse MyResp = RestUtils.SendGetRequest(Req, this.broker.RestAuthToken, this.broker.IQBotMajorVersion);
            String RESPONSE = "";

            RESPONSE = "GroupId,GroupName,GroupInternalId,GroupState,GroupIsRunning,GroupLastModifiedByUser,GroupLastModifiedTimeStamp,GroupFileCount" + "\n";


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
                RESPONSE =RESPONSE+ AllRows;
            }
            
            return RESPONSE;
        }

        public String GetAllGroupsFromLIName(Boolean RespInJsonFormat,String LiName)
        {
            String s = GetLiIDFromLiName(false,LiName);
            if (s == "")
            {
                return "";
            }
            return GetAllGroupsFromLIID(RespInJsonFormat,s);
        }
    }
}
