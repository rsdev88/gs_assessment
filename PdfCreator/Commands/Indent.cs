using System;

namespace PdfCreator.Commands
{
    public class Indent : ICommand
    {
        private readonly int indentation;

        public Indent(int indentation = 0)
        {
            this.indentation = indentation;
        }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}
