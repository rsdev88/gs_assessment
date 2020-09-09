using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator
{
    public class PdfCreator
    {
        private readonly IFileReader fileReader;

        public PdfCreator(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public void Run()
        {
            //Obtain a queue of inputs
            this.fileReader.ReadInput();

            //Pass queue to implementation of PDF generator

        }
        


    }
}
