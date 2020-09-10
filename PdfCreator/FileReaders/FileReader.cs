using Microsoft.Extensions.Configuration;
using PdfCreator.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator
{
    public class FileReader : IFileReader
    {
        private readonly IConfiguration configuration;

        public FileReader(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<ICommand> ReadInput()
        {
            var inputFilePath = this.configuration.GetValue<string>(Constants.INPUT_FILE_NAME_SETTING);

            //Look for the file and read its contents - this will throw an error if the file is not found.
            var inputArray = System.IO.File.ReadAllLines(inputFilePath);

            //Check to see if the file contained no contents.
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new FormatException(string.Format(Constants.EMPTY_INPUT_ERROR, inputFilePath));
            }

            //Map the input to a list of commands.
            return new List<ICommand>();
        }
        
    }
}
