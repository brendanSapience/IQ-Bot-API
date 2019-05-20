using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects.Doctools
{
    public class PDFToText
    {
        public class Shape
        {
            public double x { get; set; }
            public double y { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public int pageNumber { get; set; }
            public double pageWidth { get; set; }
            public double pageHeight { get; set; }
        }

        public class Child2
        {
            public string value { get; set; }
            public double fontSize { get; set; }
            public double spaceWidth { get; set; }
            public string fontName { get; set; }
            public Shape shape { get; set; }
        }

        public class Shape2
        {
            public double x { get; set; }
            public double y { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public int pageNumber { get; set; }
            public double pageWidth { get; set; }
            public double pageHeight { get; set; }
        }

        public class Child
        {
            public int pageNumber { get; set; }
            public List<Child2> children { get; set; }
            public Shape2 shape { get; set; }
        }

        public class Response
        {
            public List<Child> children { get; set; }
        }
    }
}
