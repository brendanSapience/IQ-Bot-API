using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class LearningInstanceFilesList
    {
        public class Datum
        {
            public string fileId { get; set; }
            public string projectId { get; set; }
            public string fileName { get; set; }
            public string fileLocation { get; set; }
            public int fileSize { get; set; }
            public int fileHeight { get; set; }
            public int fileWidth { get; set; }
            public string format { get; set; }
            public bool processed { get; set; }
            public string classificationId { get; set; }
            public string uploadrequestId { get; set; }
            public string layoutId { get; set; }
            public string isProduction { get; set; }
        }

        public class Response
        {
            public bool success { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
