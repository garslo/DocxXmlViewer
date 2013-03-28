# DocxXmlViewer

DocxXmlViewer is a simple tool to view the underlying OpenXml of a
Microsoft Word docx file. I wrote it to help me with a Word to LaTeX
conversion library; it's a nice little utility.

DocxXmlViewer allows you to open a Word document and view the xml 
comprising the MainDocumentPart (that is, the stuff found in 
word/document.xml inside the docx zip file). You can edit this and
re-save the document in-place, allowing quick experimentation. I've
also built in a basic validation service.

Since I wrote it for *myself*, it's not terribly polished. Exceptions
are shown as error messages, and the validation doesn't quite work as
it should yet. But it's workable.

DocxXmlViewer requires the [OpenXml SDK 2.0][OpenXml] and .NET Version 3.5
or later. It's set to build with .NET Version 4.5, but it's been tested on
3.5 and works fine.

[OpenXml]: http://www.microsoft.com/en-us/download/details.aspx?id=5124 "OpenXml SDK 2.0"