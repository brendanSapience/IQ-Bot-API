﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.IQBotCalls.DB
{
    class _600ReadDBAPICalls
    {
        IQBotConnectionBroker broker;
        public _600ReadDBAPICalls(IQBotConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String GetIQBotLINameFromID(String LiID)
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT ProjectName FROM ProjectActivityDetail where ProjectId = '"+LiID+"'");
            String LiName = sqlr["ProjectName"].ToString();
            return "{\"LIName\":\"" + LiName + "\"}";

        }

        public String GetIQBotLIIDFromName(String LiName)
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT ProjectId FROM ProjectActivityDetail where ProjectName = '" + LiName + "'");
            String LiID = sqlr["ProjectId"].ToString();
            return "{\"LIID\":\"" + LiID + "\"}";
        }

        public String GetIQBotConfiguration()
        {
            SqlDataReader sqlr = this.broker.runQuery("Configurations", "select TOP 1 * from CognitivePlatformNodes");
            return JsonUtils.getConfigAsJson(sqlr);
        }

        public String GetIQBotLearningInstances()
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM ProjectActivityDetail");
            return JsonUtils.getLIsAsJson(sqlr);
        }

        public String GetLIFiles(String LearningInstanceID)
        {
            //'8c554e14-8e1f-437e-aeec-8f363627eb6f'
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM FileDetails where projectid = '" + LearningInstanceID + "'");
            return JsonUtils.getFileListAsJson(sqlr);
        }

        public String GetLIUnclassifiedFiles(String LearningInstanceID)
        {
            //'8c554e14-8e1f-437e-aeec-8f363627eb6f'
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM FileDetails where projectid = '" + LearningInstanceID + "' AND classificationid='-1'");
            return JsonUtils.getFileListAsJson(sqlr);
        }

        public String GetLIDetails(String LearningInstanceID)
        {
            //'8c554e14-8e1f-437e-aeec-8f363627eb6f'
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM ProjectDetail where id = '" + LearningInstanceID + "'");
            return JsonUtils.getProjectListAsJson(sqlr);
        }

        public String GetFileDetails(String FileID)
        {
            //'8c554e14-8e1f-437e-aeec-8f363627eb6f'
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM SegmentedDocumentDetails where FileId = '" + FileID + "'");
            return JsonUtils.getFileDetailsAsJson(sqlr);
        }

        public String GetClassificationReport(String DocumentID)
        {
            //'8c554e14-8e1f-437e-aeec-8f363627eb6f'
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM ClassificationReport where documentId = '" + DocumentID + "'");
            return JsonUtils.getClassificationReportAsJson(sqlr);
        }

        public String GetCustomFields(String LearningInstanceID)
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM CustomFieldDetail where ProjectId = '" + LearningInstanceID + "'");
            return JsonUtils.getCustomFieldsAsJson(sqlr);
        }

        public String GetInvalidFiles()
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM InvalidFiles");
            return JsonUtils.getInvalidFilesAsJson(sqlr);
        }

        public String GetExportImportActivities()
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM Tasks");
            return JsonUtils.getExportActivityAsJson(sqlr);
        }

        public String GetListOfCorrectedValues()
        {
            SqlDataReader sqlr = this.broker.runQuery("MLData", "SELECT * FROM trainingdata");
            return JsonUtils.getTrainingDataAsJson(sqlr);
        }

        public String GetListOfDomains()
        {
            SqlDataReader sqlr = this.broker.runQuery("AliasData", "SELECT * FROM DocTypeMaster");
            return JsonUtils.getDomainListAsJson(sqlr);
        }

        public String GetListOfLanguages()
        {
            SqlDataReader sqlr = this.broker.runQuery("AliasData", "SELECT * FROM LanguageMaster");
            return JsonUtils.getLanguageListAsJson(sqlr);
        }

        //SELECT distinct filename,classificationid from [FileManager].[dbo].[FileDetails] where filename='1001748643.pdf';
        public String GetGroupFromFilename(String FileName)
        {
            String SQLQuery = "SELECT distinct filename,classificationid from [FileManager].[dbo].[FileDetails] where filename='" + FileName + "';";
            SqlDataReader sqlr = this.broker.runQuery("FileManager", SQLQuery);
            return JsonUtils.getGroupFromFileAsJson(sqlr);
        }
    }
}
