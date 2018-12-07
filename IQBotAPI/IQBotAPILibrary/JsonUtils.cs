using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IQBotAPILibrary
{
    class JsonUtils
    {

        public static String getConfigAsJson(SqlDataReader sdr)
        {
            String Resp = "{";
            while (sdr.Read())
            {
                String CtrlRoomURL = sdr["ControlRoomURL"].ToString();
                String NodeName = sdr["NodeName"].ToString();
                String LoadBalancerURL = sdr["LoadBalancerURL"].ToString();
                String ClientPlatformUrl = sdr["ClientPlatformUrl"].ToString();
                String OutputPath = sdr["OutputPath"].ToString();

                OutputPath = OutputPath.Replace('\\', '/');

                Resp = Resp + "\"Nodename\":" + "\"" + NodeName + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"CtrlRoomURL\":" + "\"" + CtrlRoomURL + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"LoadBalancerURL\":" + "\"" + LoadBalancerURL + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"ClientPlatformUrl\":" + "\"" + ClientPlatformUrl + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"OutputPath\":" + "\"" + OutputPath + "\"";

            }
            Resp = Resp + "}";
            return Resp;
        }

        public static String getLIsAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"LearningInstances\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String ProjectId = sdr["ProjectId"].ToString();
                String ProjectName = sdr["ProjectName"].ToString();
                String ActivityAt = sdr["ActivityAt"].ToString();
                String UpdateBy = sdr["UpdatedBy"].ToString();


                InnerResp = InnerResp + "\"LIID\":" + "\"" + ProjectId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"LIName\":" + "\"" + ProjectName + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"ActivityAt\":" + "\"" + ActivityAt + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"UpdateBy\":" + "\"" + UpdateBy + "\"";
                InnerResp = InnerResp + "},";

            }
            
            Resp = Resp+InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }
    }
}
