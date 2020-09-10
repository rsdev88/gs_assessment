using PdfCreator.Commands;
using System.Collections.Generic;

namespace PdfCreator.InputMappers
{
    public interface IMapper
    {
        Queue<ICommand> MapInputFromArray(string[] inputArray);
    }
}
