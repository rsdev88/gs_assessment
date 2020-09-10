using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class BoldTests
    {
        [TestCase(FontFormat.Regular)]
        [TestCase(FontFormat.Bold)]
        public void ProcessAppendsBoldTagToStringBuilder(FontFormat currentFontFormat)
        {
            //Arrange
            var boldCommand = new Bold();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontFormat = currentFontFormat;

            var expectedValue = "<b>";

            //Act
            boldCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontFormat.Bold, currentPdf.CurrentFontFormat);
        }

        [Test]
        public void ProcessClosesItalicsTagIfFontFormatIsCurrentlyItalics()
        {
            //Arrange
            var boldCommand = new Bold();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontFormat = FontFormat.Italics;

            var expectedValue = "</i><b>";

            //Act
            boldCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontFormat.Bold, currentPdf.CurrentFontFormat);
        }
    }
}
