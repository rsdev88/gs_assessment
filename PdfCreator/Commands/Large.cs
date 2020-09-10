using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Large : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            if (currentPdf.CurrentFontSize == FontSize.Normal)
            {
                currentPdf.StringBuilder.Append("</font>");
            }

            currentPdf.StringBuilder.AppendFormat("<font pointSize='{0}'>", (int)FontSize.Large);
            currentPdf.CurrentFontSize = FontSize.Large;
        }
    }
}
