using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Bold : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            if (currentPdf.CurrentFontFormat == FontFormat.Italics)
            {
                currentPdf.StringBuilder.Append("</i>");
            }

            currentPdf.StringBuilder.Append("<b>");
            currentPdf.CurrentFontFormat = FontFormat.Bold;
        }
    }
}
