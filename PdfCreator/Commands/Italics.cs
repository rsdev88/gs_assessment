using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Italics : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            if (currentPdf.CurrentFontFormat == FontFormat.Bold)
            {
                currentPdf.StringBuilder.Append("</b>");
            }

            currentPdf.StringBuilder.Append("<i>");
            currentPdf.CurrentFontFormat = FontFormat.Italics;
        }
    }
}
