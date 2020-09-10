using PdfCreator.PdfGenerators;
using System;

namespace PdfCreator.Commands
{
    public class NoFill : ICommand
    {
        public void Process(ref CurrentPdf currentPdf)
        {
            throw new NotImplementedException();
        }
    }
}
