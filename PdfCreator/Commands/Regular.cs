using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Regular : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            if (currentPdf.CurrentFontFormat == FontFormat.Bold)
            {
                currentPdf.StringBuilder.Append("</b>");
            }
            else if (currentPdf.CurrentFontFormat == FontFormat.Italics)
            {
                currentPdf.StringBuilder.Append("</i>");
            }

            currentPdf.CurrentFontFormat = FontFormat.Regular;
        }
    }
}
