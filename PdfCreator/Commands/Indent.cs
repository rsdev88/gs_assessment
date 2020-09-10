using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class Indent : ICommand
    {
        private readonly int indentation;
        public int Indentation { get { return this.indentation; } }

        public Indent(string value = "")
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(Constants.INDENTATION_COMMAND_NAME, "").Trim();

                if (! int.TryParse(value, out indentation))
                {
                    this.indentation = 0;
                }
            }
        }

        public void Process(ref CurrentPdf currentPdf)
        {
            throw new NotImplementedException();
        }
    }
}
