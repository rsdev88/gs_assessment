using Microsoft.Extensions.Configuration;
using PdfCreator.Commands;
using PdfCreator.InputMappers;
using System;
using System.Collections.Generic;

namespace PdfCreator.FileReaders
{
    public class FileReader : IFileReader
    {
        private readonly IConfiguration configuration;
        private readonly IMapper inputMapper;

        public FileReader(IConfiguration configuration, IMapper inputMapper)
        {
            this.configuration = configuration;
            this.inputMapper = inputMapper;
        }

        public Queue<ICommand> ReadInput()
        {
            var inputFilePath = this.configuration.GetValue<string>(Constants.INPUT_FILE_NAME_SETTING);

            //Look for the file and read its contents - this will throw an FileNotFound exception if the file is not found.
            var inputArray = System.IO.File.ReadAllLines(inputFilePath);

            //Check to see if the file contained no contents.
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new FormatException(string.Format(Constants.EMPTY_INPUT_ERROR, inputFilePath));
            }

            return this.inputMapper.MapInputFromArray(inputArray);
        }
        
    }
}
