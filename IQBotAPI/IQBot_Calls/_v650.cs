using IQBotAPILibrary;
using IQBotAPILibrary.IQBotCalls.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBot_Calls
{
    
    public class _v650
    {
        public static int ALIASPORT = 9996;

        public static String _GetAuthorizationToken(String CRUrl, int CRPort, String CRLogin, String CRPassword, Boolean JsonResponse)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, CRLogin, CRPassword, ALIASPORT);
            String token = rbroker.RestAuthToken;
            String resp;

            if (JsonResponse)
            {
                resp = "{\"token\":\"" + token + "\"}";
            }
            else
            {
                resp = token;
            }
            //Console.WriteLine("DEBUG Resp Auth: " + resp);
            return resp;
        }

        public static String GetGroupLayoutInfo(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId, int GroupNumber, Boolean ShowAllInfo)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetGroupLayout(JsonResponse, LearningInstanceId,GroupNumber, ShowAllInfo);
            return resp;
        }


        public static String GetLearningInstanceFileList(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetFileListFromLearningInstance(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstanceValidationQueueCurrentCount(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceValidationQueueCurrentCount(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetValidationQueueSummary(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceValidationSummary(JsonResponse,LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstanceInfoPROD(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceDetailsPROD(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstanceInfoSTAGING(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceDetailsSTAGING(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstances(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllLearningInstances(JsonResponse);
            return resp;
        }

        public static String GetGroupsFromLearningInstance(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllGroupsFromLIID(JsonResponse,LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstanceStatistics(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceStatistics(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetFieldAccuracyStatistics(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceFieldAccuracyStatistics(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetFieldClassificationStatistics(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceFieldlCassificationStatistics(JsonResponse, LearningInstanceId);
            return resp;
        }

        public static String GetLearningInstanceIDFromName(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceName)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLiIDFromLiName(JsonResponse, LearningInstanceName);
            return resp;
        }

        public static String GetLearningInstanceNameFromID(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceID)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLiNameFromLiID(JsonResponse, LearningInstanceID);
            return resp;
        }

        public static String GetGroupsFromLearningInstanceID(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceID)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllGroupsFromLIID(JsonResponse, LearningInstanceID);
            return resp;
        }

        public static String GetGroupsFromLearningInstanceName(String CRUrl, int CRPort, String AuthToken, Boolean JsonResponse, String LearningInstanceName)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, AuthToken, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllGroupsFromLIName(JsonResponse, LearningInstanceName);
            return resp;
        }
    }
}
