using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class LearningInstanceDetails
    {
        public class Data
        {
            public int stagingTotalGroups { get; set; }
            public int stagingTotalBots { get; set; }
            public int stagingDocumentsUnclassified { get; set; }
            public int stagingSuccessFiles { get; set; }
            public int stagingFailedFiles { get; set; }
            public int stagingAccuracy { get; set; }
            public int stagingTestedFiles { get; set; }
            public int stagingTotalFiles { get; set; }
            public int stagingPageCount { get; set; }
            public int stagingSTP { get; set; }
            public int productionTotalGroups { get; set; }
            public int productionTotalBots { get; set; }
            public int productionDocumentsUnclassified { get; set; }
            public int productionSuccessFiles { get; set; }
            public int productionReviewFiles { get; set; }
            public int productionInvalidFiles { get; set; }
            public int productionAccuracy { get; set; }
            public int productionProcessedFiles { get; set; }
            public int productionTotalFiles { get; set; }
            public int productionPageCount { get; set; }
            public int productionSTP { get; set; }
            public int pendingForReview { get; set; }
            public int stagingTestedFilesPercentage { get; set; }
            public int productionProcessedFilesPercentage { get; set; }
        }

        public class Response
        {
            public bool success { get; set; }
            public Data data { get; set; }
            public List<object> errors { get; set; }
        }
    }
}
