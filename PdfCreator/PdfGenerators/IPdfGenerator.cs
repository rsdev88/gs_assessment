using PdfCreator.Commands;
using System.Collections.Generic;

namespace PdfCreator.PdfGenerators
{
    public interface IPdfGenerator
    {
        void BuildPdf(Queue<ICommand> commands);
    }
}
