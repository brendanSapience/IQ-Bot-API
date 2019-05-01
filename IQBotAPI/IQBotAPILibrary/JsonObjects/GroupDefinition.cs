using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    class GroupDefinition
    {

        public class Settings
        {
            public bool EnableAutoRotation { get; set; }
            public bool EnablePageOrientation { get; set; }
            public bool EnableBorderFilter { get; set; }
            public bool EnableBinarization { get; set; }
            public bool EnableGrayscaleConversion { get; set; }
            public bool EnableNoiseFilter { get; set; }
            public bool EnableRemoveLines { get; set; }
            public bool EnableContrastStretch { get; set; }
            public int BinarizationType { get; set; }
            public int NoiseThreshold { get; set; }
            public int BinarizationThreshold { get; set; }
            public bool EnbleBackgroundRemoval { get; set; }
            public bool PreserveOriginalDpi { get; set; }
            public bool UseVectorInfoInPdf { get; set; }
            public bool IsTesseract4Engine { get; set; }
        }

        public class PageProperty
        {
            public int PageIndex { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string BorderRect { get; set; }
        }

        public class DocProperties
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public int Type { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int RenderDPI { get; set; }
            public string LanguageCode { get; set; }
            public string BorderRect { get; set; }
            public List<PageProperty> PageProperties { get; set; }
            public int Version { get; set; }
        }

        public class Line
        {
            public int X1 { get; set; }
            public int Y1 { get; set; }
            public int X2 { get; set; }
            public int Y2 { get; set; }
        }

        public class Field
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string Text { get; set; }
            public int Confidence { get; set; }
            public int SegmentationType { get; set; }
            public int Type { get; set; }
            public string Bounds { get; set; }
            public int Angle { get; set; }
        }

        public class Region
        {
            public string Id { get; set; }
            public object ParentId { get; set; }
            public string Text { get; set; }
            public int Confidence { get; set; }
            public int SegmentationType { get; set; }
            public int Type { get; set; }
            public string Bounds { get; set; }
            public int Angle { get; set; }
        }

        public class SirFields
        {
            public List<Line> Lines { get; set; }
            public List<Field> Fields { get; set; }
            public List<Region> Regions { get; set; }
        }

        public class Field2
        {
            public string Id { get; set; }
            public string FieldId { get; set; }
            public string RelationalFieldDefId { get; set; }
            public string Label { get; set; }
            public string StartsWith { get; set; }
            public string EndsWith { get; set; }
            public string FormatExpression { get; set; }
            public string DisplayValue { get; set; }
            public bool IsMultiline { get; set; }
            public string Bounds { get; set; }
            public string ValueBounds { get; set; }
            public int FieldDirection { get; set; }
            public int MergeRatio { get; set; }
            public double SimilarityFactor { get; set; }
            public int Type { get; set; }
            public int XDistant { get; set; }
            public bool IsValueBoundAuto { get; set; }
            public int ValueType { get; set; }
            public string IsDollarCurrency { get; set; }
        }

        public class Layout
        {
            public Settings Settings { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public DocProperties DocProperties { get; set; }
            public string VBotDocSetId { get; set; }
            public object VBotTestDocSetId { get; set; }
            public SirFields SirFields { get; set; }
            public List<Field2> Fields { get; set; }
            public List<object> Tables { get; set; }
            public List<object> Identifiers { get; set; }
        }

        public class Field3
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int ValueType { get; set; }
            public string Formula { get; set; }
            public string ValidationID { get; set; }
            public bool IsRequired { get; set; }
            public string DefaultValue { get; set; }
            public string StartsWith { get; set; }
            public string EndsWith { get; set; }
            public string FormatExpression { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class Table
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<object> Columns { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DataModel
        {
            public List<Field3> Fields { get; set; }
            public List<Table> Tables { get; set; }
        }

        public class DataModelIdStructure
        {
            public string FieldId { get; set; }
            public string TableDefId { get; set; }
            public string ColumnId { get; set; }
        }

        public class Settings2
        {
            public bool EnableAutoRotation { get; set; }
            public bool EnablePageOrientation { get; set; }
            public bool EnableBorderFilter { get; set; }
            public bool EnableBinarization { get; set; }
            public bool EnableGrayscaleConversion { get; set; }
            public bool EnableNoiseFilter { get; set; }
            public bool EnableRemoveLines { get; set; }
            public bool EnableContrastStretch { get; set; }
            public int BinarizationType { get; set; }
            public int NoiseThreshold { get; set; }
            public int BinarizationThreshold { get; set; }
            public bool EnbleBackgroundRemoval { get; set; }
            public bool PreserveOriginalDpi { get; set; }
            public bool UseVectorInfoInPdf { get; set; }
            public bool IsTesseract4Engine { get; set; }
        }

        public class VisionBotData
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Version { get; set; }
            public List<Layout> Layouts { get; set; }
            public DataModel DataModel { get; set; }
            public DataModelIdStructure DataModelIdStructure { get; set; }
            public Settings2 Settings { get; set; }
            public string Language { get; set; }
        }

        public class Response
        {
            public VisionBotData visionBotData { get; set; }
            public string url { get; set; }
        }
    }
}
