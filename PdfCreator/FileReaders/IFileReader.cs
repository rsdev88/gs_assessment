using PdfCreator.Commands;
using System.Collections.Generic;

namespace PdfCreator.FileReaders
{
    public interface IFileReader
    {
        Queue<ICommand> ReadInput();
    }
}
