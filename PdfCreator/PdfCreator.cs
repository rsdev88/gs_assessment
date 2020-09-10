using PdfCreator.FileReaders;
using PdfCreator.PdfGenerators;

namespace PdfCreator
{
    public class PdfCreator
    {
        private readonly IFileReader fileReader;
        private readonly IPdfGenerator pdfGenerator;

        public PdfCreator(IFileReader fileReader, IPdfGenerator pdfGenerator)
        {
            this.fileReader = fileReader;
            this.pdfGenerator = pdfGenerator;
        }

        public void Run()
        {
            //Obtain a queue of inputs
            var commandList = this.fileReader.ReadInput();

            //Pass queue to implementation of PDF generator
            this.pdfGenerator.BuildPdf(commandList);
        }
    }
}
