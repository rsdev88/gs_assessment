using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Normal : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            if (currentPdf.CurrentFontSize == FontSize.Large)
            {
                currentPdf.StringBuilder.Append("</font>");
            }

            currentPdf.StringBuilder.AppendFormat("<font pointSize='{0}'>", (int)FontSize.Normal);
            currentPdf.CurrentFontSize = FontSize.Normal;
        }
    }
}
