using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using Microsoft.Extensions.Configuration;
using PdfCreator.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreator.PdfGenerators
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IConfiguration configuration;

        public PdfGenerator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void BuildPdf(Queue<ICommand> commands)
        {
            if (commands == null || commands.Count == 0)
            {
                throw new ArgumentException(Constants.NO_COMMANDS_TO_PROCESS_ERROR);
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<p><font pointSize='{0}'>", (int)FontSize.Normal);

            var currentPdf= new CurrentPdf();
            currentPdf.StringBuilder = stringBuilder;


            //Process the queue of commands to build up a formatted string of text
            while (commands.Count > 0)
            {
                var currentCommand = commands.Dequeue();
                if (currentCommand != null)
                {
                    currentCommand.Process(ref currentPdf);
                }
            }
            currentPdf.StringBuilder.Append($"</p>");

            //Create a PDF document, add the formatted string of text to it and save it.
            var pdfDocument = new Document();

            var page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            pdfDocument.Pages.Add(page);

            var style = new FormattedTextAreaStyle(FontFamily.Helvetica, 12, false);
            var formattedTextArea = new FormattedTextArea(currentPdf.StringBuilder.ToString(), 0, 0, 500, 1000, style);
            page.Elements.Add(formattedTextArea);

            pdfDocument.Draw(this.configuration.GetValue<string>(Constants.OUTPUT_FILE_NAME_SETTING));
        }
    }
}
