
using PdfCreator.PdfGenerators;

namespace PdfCreator.Commands
{
    public interface ICommand
    {
        void Process(ref CurrentPdf currentPdf);
    }
}
