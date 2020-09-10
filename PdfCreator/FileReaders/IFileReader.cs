using PdfCreator.Commands;
using System.Collections.Generic;

namespace PdfCreator
{
    public interface IFileReader
    {
        List<ICommand> ReadInput();
    }
}
