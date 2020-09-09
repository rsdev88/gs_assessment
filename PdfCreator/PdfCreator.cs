using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator
{
    public class PdfCreator
    {
        private readonly IConfiguration configuration;
        private const string inputFileSettingName = "inputFilePath";

        public PdfCreator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Run()
        {
            var inputFilePath = this.configuration.GetValue<string>(inputFileSettingName);
            var inputArray = System.IO.File.ReadAllLines(inputFilePath);

        }
        


    }
}
