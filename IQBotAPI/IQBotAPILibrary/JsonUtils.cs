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

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getFileListAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"Files\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String FileId = sdr["fileid"].ToString();
                String FileName = sdr["filename"].ToString();
                String FileSize = sdr["filesize"].ToString();
                String ClassificationID = sdr["classificationid"].ToString();


                InnerResp = InnerResp + "\"FileId\":" + "\"" + FileId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"FileName\":" + "\"" + FileName + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"FileSize\":" + "\"" + FileSize + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"ClassificationID\":" + "\"" + ClassificationID + "\"";
                InnerResp = InnerResp + "},";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }
        public static String getProjectListAsJson(SqlDataReader sdr)
        {
            String Resp = "{";
            while (sdr.Read())
            {
                String Id = sdr["Id"].ToString();
                String Name = sdr["Name"].ToString();
                String Description = sdr["Description"].ToString();
                String Type = sdr["Type"].ToString();
                String Typeid = sdr["Typeid"].ToString();
                String PrimaryLanguage = sdr["PrimaryLanguage"].ToString();
                String State = sdr["State"].ToString();
                String Environment = sdr["Environment"].ToString();
                String FileUploadToken = sdr["FileUploadToken"].ToString();
                String FileUploadTokenAlive = sdr["FileUploadTokenAlive"].ToString();
                String CreatedAt = sdr["CreatedAt"].ToString();
                String UpdatedAt = sdr["UpdatedAt"].ToString();
                String VersionID = sdr["VersionId"].ToString();



                Resp = Resp + "\"Id\":" + "\"" + Id + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"Name\":" + "\"" + Name + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"Description\":" + "\"" + Description + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"Type\":" + "\"" + Type + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"TypeID\":" + "\"" + Typeid + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"PrimaryLanguage\":" + "\"" + PrimaryLanguage + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"State\":" + "\"" + State + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"Environment\":" + "\"" + Environment + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"FileUploadToken\":" + "\"" + FileUploadToken + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"FileUploadTokenAlive\":" + "\"" + FileUploadTokenAlive + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"CreatedAt\":" + "\"" + CreatedAt + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"UpdatedAt\":" + "\"" + UpdatedAt + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"VersionID\":" + "\"" + VersionID + "\"";

            }
            Resp = Resp + "}";
            return Resp;
        }

        //
        public static String getFileDetailsAsJson(SqlDataReader sdr)
        {
            String SegmentedDocument = "";
            while (sdr.Read())
            {
                SegmentedDocument = sdr["SegmentedDocument"].ToString();
            }
            return SegmentedDocument;
        }

        public static String getClassificationReportAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"Report\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String FieldId = sdr["fieldId"].ToString();
                String AliasName = sdr["aliasName"].ToString();
                String IsFound = sdr["isFound"].ToString();



                InnerResp = InnerResp + "\"FieldId\":" + "\"" + FieldId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"AliasName\":" + "\"" + AliasName + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"IsFound\":" + "\"" + IsFound + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getCustomFieldsAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"CustomFields\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String Id = sdr["Id"].ToString();
                String Name = sdr["Name"].ToString();
                String FieldType = sdr["FieldType"].ToString();
                String IsAddedLater = sdr["IsAddedLater"].ToString();
                String OrderNumber = sdr["OrderNumber"].ToString();


                InnerResp = InnerResp + "\"Id\":" + "\"" + Id + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"Name\":" + "\"" + Name + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"FieldType\":" + "\"" + FieldType + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"IsAddedLater\":" + "\"" + IsAddedLater + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"OrderNumber\":" + "\"" + OrderNumber + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getInvalidFilesAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"InvalidFiles\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String FileId = sdr["FileId"].ToString();
                String ReasonId = sdr["ReasonId"].ToString();
                String ReasonText = sdr["ReasonText"].ToString();

                InnerResp = InnerResp + "\"FileId\":" + "\"" + FileId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"ReasonId\":" + "\"" + ReasonId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"ReasonText\":" + "\"" + ReasonText + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }


        public static String getExportActivityAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"Tasks\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String TaskId = sdr["TaskId"].ToString();
                String TaskType = sdr["TaskType"].ToString();
                String Status = sdr["Status"].ToString();
                String Description = sdr["Description"].ToString();
                String CreatedBy = sdr["CreatedBy"].ToString();
                String StartTime = sdr["StartTime"].ToString();
                String EndTime = sdr["EndTime"].ToString();
                String TaskOptions = sdr["TaskOptions"].ToString();

                Description = Description.Replace('\\', '/');

                InnerResp = InnerResp + "\"TaskId\":" + "\"" + TaskId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"TaskType\":" + "\"" + TaskType + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"Status\":" + "\"" + Status + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"Description\":" + "\"" + Description + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"StartTime\":" + "\"" + StartTime + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"EndTime\":" + "\"" + EndTime + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"TaskOptions\":" + "\"" + TaskOptions + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getTrainingDataAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"TrainingData\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String OriginalValue = sdr["originalvalue"].ToString();
                String CorrectedValue = sdr["correctedvalue"].ToString();
                String FiledId = sdr["fieldid"].ToString();
                String CorrectedOn = sdr["correctedon"].ToString();


                //Description = Description.Replace('\\', '/');

                InnerResp = InnerResp + "\"OriginalValue\":" + "\"" + OriginalValue + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"CorrectedValue\":" + "\"" + CorrectedValue + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"FiledId\":" + "\"" + FiledId + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"CorrectedOn\":" + "\"" + CorrectedOn + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getDomainListAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"Domains\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String Id = sdr["Id"].ToString();
                String Name = sdr["Name"].ToString();
                String LanguageId = sdr["LanguageId"].ToString();


                //Description = Description.Replace('\\', '/');

                InnerResp = InnerResp + "\"Id\":" + "\"" + Id + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"Name\":" + "\"" + Name + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"LanguageId\":" + "\"" + LanguageId + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getLanguageListAsJson(SqlDataReader sdr)
        {
            String Resp = "{\"Languages\":[";
            String InnerResp = "";
            while (sdr.Read())
            {
                InnerResp = InnerResp + "{";
                String Id = sdr["Id"].ToString();
                String Name = sdr["Name"].ToString();
                String Code = sdr["Code"].ToString();


                //Description = Description.Replace('\\', '/');

                InnerResp = InnerResp + "\"Id\":" + "\"" + Id + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"Name\":" + "\"" + Name + "\"";
                InnerResp = InnerResp + ",";
                InnerResp = InnerResp + "\"LanguageId\":" + "\"" + Code + "\"";
                InnerResp = InnerResp + "}";
                InnerResp = InnerResp + ",";

            }

            Resp = Resp + InnerResp.TrimEnd(',') + "]}";
            return Resp;
        }

        public static String getGroupFromFileAsJson(SqlDataReader sdr)
        {
            String Resp = "{";
            while (sdr.Read())
            {
                String FileName = sdr["filename"].ToString();
                String Group = sdr["classificationid"].ToString();

                Resp = Resp + "\"FileName\":" + "\"" + FileName + "\"";
                Resp = Resp + ",";
                Resp = Resp + "\"Group\":" + "\"" + Group + "\"";

            }
            Resp = Resp + "}";
            return Resp;
        }
    }

}
