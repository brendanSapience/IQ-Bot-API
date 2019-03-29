using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class GroupsList
    {


        public class AllFieldDetail
        {
            public string fieldId { get; set; }
            public int foundInTotalDocs { get; set; }
        }

        public class CategoryDetail
        {
            public string id { get; set; }
            public int noOfDocuments { get; set; }
            public int priority { get; set; }
            public int index { get; set; }
            public List<AllFieldDetail> allFieldDetail { get; set; }
        }

        public class VisionBot
        {
            public string id { get; set; }
            public string name { get; set; }
            public string currentState { get; set; }
            public bool running { get; set; }
            public object lockedUserId { get; set; }
            public string lastModifiedByUser { get; set; }
            public string lastModifiedTimestamp { get; set; }
        }

        public class ProductionFileDetails
        {
            public int totalCount { get; set; }
            public int totalSTPCount { get; set; }
            public int unprocessedCount { get; set; }
        }

        public class StagingFileDetails
        {
            public int totalCount { get; set; }
            public int totalSTPCount { get; set; }
            public int unprocessedCount { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public CategoryDetail categoryDetail { get; set; }
            public VisionBot visionBot { get; set; }
            public int fileCount { get; set; }
            public object files { get; set; }
            public ProductionFileDetails productionFileDetails { get; set; }
            public StagingFileDetails stagingFileDetails { get; set; }
        }

        public class Data
        {
            public int offset { get; set; }
            public int limit { get; set; }
            public string sort { get; set; }
            public List<Category> categories { get; set; }
        }

        public class Response
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }
    }
}
