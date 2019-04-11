using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class LearningInstanceStats
    {
        public class FieldRepresentation
        {
            public string name { get; set; }
            public int representationPercent { get; set; }
        }

        public class Classification
        {
            public List<FieldRepresentation> fieldRepresentation { get; set; }
        }

        public class Field
        {
            public string name { get; set; }
            public int accuracyPercent { get; set; }
        }

        public class Accuracy
        {
            public List<Field> fields { get; set; }
        }

        public class Field2
        {
            public string fieldId { get; set; }
            public int percentValidated { get; set; }
        }

        public class Validation
        {
            public List<Field2> fields { get; set; }
            public List<object> categories { get; set; }
        }

        public class Data
        {
            public int totalFilesProcessed { get; set; }
            public int totalSTP { get; set; }
            public int totalAccuracy { get; set; }
            public int totalFilesUploaded { get; set; }
            public int totalFilesToValidation { get; set; }
            public int totalFilesValidated { get; set; }
            public int totalFilesUnprocessable { get; set; }
            public Classification classification { get; set; }
            public Accuracy accuracy { get; set; }
            public Validation validation { get; set; }
            public int totalStagingPageCount { get; set; }
            public int totalProductionPageCount { get; set; }
        }

        public class Response
        {
            public bool success { get; set; }
            public Data data { get; set; }
            public object errors { get; set; }
        }

    }
}
