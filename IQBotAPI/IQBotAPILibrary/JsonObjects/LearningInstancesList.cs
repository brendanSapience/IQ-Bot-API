using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class LearningInstancesList
    {
        public class Fields
        {
            public List<object> standard { get; set; }
            public List<object> custom { get; set; }
        }

        public class OcrEngineDetail
        {
            public string id { get; set; }
            public object name { get; set; }
            public string engineType { get; set; }
        }

        public class Datum
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string organizationId { get; set; }
            public string projectTypeId { get; set; }
            public string projectType { get; set; }
            public int confidenceThreshold { get; set; }
            public int numberOfFiles { get; set; }
            public int numberOfCategories { get; set; }
            public int unprocessedFileCount { get; set; }
            public string primaryLanguage { get; set; }
            public int accuracyPercentage { get; set; }
            public int visionBotCount { get; set; }
            public int currentTrainedPercentage { get; set; }
            public object categories { get; set; }
            public Fields fields { get; set; }
            public string projectState { get; set; }
            public string environment { get; set; }
            public object updatedAt { get; set; }
            public object createdAt { get; set; }
            public List<OcrEngineDetail> ocrEngineDetails { get; set; }
            public int versionId { get; set; }
        }

        public class Response
        {
            public bool success { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
