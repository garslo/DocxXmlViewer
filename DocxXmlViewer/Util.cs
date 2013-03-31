using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Validation;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DocxXmlViewer
{
    static class Util
    {
        public static string GetFormattedXml(string docxPath)
        {
            string xml = GetXml(docxPath);
            // XDocument.Parse() formats things nicely.
            return XDocument.Parse(xml).ToString();
        }

        private static string GetXml(string docxPath)
        {
            using (var docx = WordprocessingDocument.Open(docxPath, false))
            {
                return docx.MainDocumentPart.Document.OuterXml;
            }
        }


        public static void SaveAsDocx(string xmlContents, string docxPath)
        {
            using (var docx = WordprocessingDocument.Open(docxPath, true))
            {
                docx.MainDocumentPart.Document = AsDocument(xmlContents);
            }
        }


        public static Document AsDocument(string xmlContents)
        {
            return new Document(xmlContents);
        }


        public static IEnumerable<ValidationErrorInfo> Validate(this Document docx)
        {
            var validator = new OpenXmlValidator();
            IEnumerable<ValidationErrorInfo> errors = validator.Validate(docx);
            return errors;
        }


        public static void Display(this IEnumerable<ValidationErrorInfo> errors)
        {
            var errorDisplay = new ErrorDisplay();
            foreach(var error in errors)
                errorDisplay.Append(error.BuildErrorString());
        }

        private static void Append(this ErrorDisplay window, string text)
        {
            window.ErrorTextBox.AppendText(Environment.NewLine);
            window.ErrorTextBox.AppendText(text);
        }

        private static string BuildErrorString(this ValidationErrorInfo error)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Id: " + error.Id);
            builder.AppendLine("Description: " + error.Description);
            builder.AppendLine("Node: " + error.Node);
            return builder.ToString();
        }
    }
}
