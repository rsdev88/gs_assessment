using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class RegularTests
    {
        [TestCase(FontFormat.Regular, "")]
        [TestCase(FontFormat.Bold, "</b>")]
        [TestCase(FontFormat.Italics, "</i>")]
        public void ProcessSetsFontFormatToRegularAndClosesExistingFormatTagsIfAppropriate(FontFormat currentFontFormat, string expectedValue)
        {
            //Arrange
            var regularCommand = new Regular();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontFormat = currentFontFormat;

            //Act
            regularCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontFormat.Regular, currentPdf.CurrentFontFormat);
        }
    }
}
