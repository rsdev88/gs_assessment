using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Paragraph : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            currentPdf.StringBuilder.Append("</p>");
            currentPdf.StringBuilder.Append("<p>");
        }
    }
}
