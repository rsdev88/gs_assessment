using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator
{
    public class FileReader : IFileReader
    {
        private const string INPUT_FILE_NAME_SETTING = "inputFilePath";
        private const string EMPTY_INPUT_ERROR = "The input file at {0} was empty. Please give it some contents and re-run the program.";

        private readonly IConfiguration configuration;

        public FileReader(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ReadInput()
        {
            var inputFilePath = this.configuration.GetValue<string>(INPUT_FILE_NAME_SETTING);

            //Look for the file and read its contents - this will throw an error if the file is not found.
            var inputArray = System.IO.File.ReadAllLines(inputFilePath);

            //Check to see if the file contained no contents.
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new Exception(string.Format(EMPTY_INPUT_ERROR, inputFilePath));
            }

            //Map the input to a list of commands.
        }
        
    }
}
