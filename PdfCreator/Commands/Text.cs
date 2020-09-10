using System;

namespace PdfCreator.Commands
{
    public class Text : ICommand
    {
        private readonly string value;
        public string Value { get { return this.value; } }

        public Text(string value = "")
        {
            this.value = value;
        }

        public void Process()
        {
            throw new NotImplementedException();
        }


    }
}
