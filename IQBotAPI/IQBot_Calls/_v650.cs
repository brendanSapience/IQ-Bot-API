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

        public static String GetLearningInstances(String CRUrl, int CRPort, String CRLogin, String CRPassword, Boolean JsonResponse)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, CRLogin, CRPassword, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllLearningInstances(JsonResponse);
            return resp;
        }

        public static String GetGroupsFromLearningInstance(String CRUrl, int CRPort, String CRLogin, String CRPassword, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, CRLogin, CRPassword, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetAllGroupsFromLIID(LearningInstanceId, false);
            return resp;
        }

        public static String GetLearningInstanceStatistics(String CRUrl, int CRPort, String CRLogin, String CRPassword, Boolean JsonResponse, String LearningInstanceId)
        {
            IQBotConnectionBroker rbroker = new IQBotConnectionBroker(6, CRUrl, CRPort, CRLogin, CRPassword, ALIASPORT);
            _600ReadRestAPICalls apicallsRest = new _600ReadRestAPICalls(rbroker);
            String resp = apicallsRest.GetLearningInstanceStatistics(false, LearningInstanceId);
            return resp;
        }
    }
}
