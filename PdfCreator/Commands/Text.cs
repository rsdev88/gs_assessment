using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Text : ICommand
    {
        public string Value { get; }

        public Text(string value = "")
        {
            this.Value = value;
        }

        public void Process(ref CurrentPdf currentPdf)
        {
            currentPdf.StringBuilder.Append(this.Value + " ");
        }
    }
}
