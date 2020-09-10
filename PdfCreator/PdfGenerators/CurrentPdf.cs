using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System.Text;

namespace PdfCreator.PdfGenerators
{
    public enum FontSize
    {
        Normal = 12,
        Large = 24
    }

    public enum Formatting
    {
        Fill,
        NoFill
    }

    public enum FontFormat
    {
        Regular,
        Italics,
        Bold
    }

    public class CurrentPdf
    {
        public CurrentPdf()
        {
            CurrentFontSize = FontSize.Normal;
            CurrentFormatting = Formatting.NoFill;
            CurrentFontFormat = FontFormat.Regular;
            CurrentIndentation = 0;
        }

        public StringBuilder StringBuilder { get; set; }

        public Document PdfDocument {get; set;}

        public Page CurrentPage { get; set; }

        public FormattedTextArea CurrentTextArea { get; set; }

        public FontSize CurrentFontSize { get; set; }

        public Formatting CurrentFormatting { get; set; }

        public FontFormat CurrentFontFormat { get; set; }
        
        public int CurrentIndentation { get; set; }
    }
}
