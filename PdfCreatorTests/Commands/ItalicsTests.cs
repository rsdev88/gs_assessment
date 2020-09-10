using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class ItalicsTests
    {
        [TestCase(FontFormat.Regular)]
        [TestCase(FontFormat.Italics)]
        public void ProcessAppendsItalicsTagToStringBuilder(FontFormat currentFontFormat)
        {
            //Arrange
            var italicsCommand = new Italics();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontFormat = currentFontFormat;

            var expectedValue = "<i>";

            //Act
            italicsCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontFormat.Italics, currentPdf.CurrentFontFormat);
        }

        [Test]
        public void ProcessClosesTagBoldIfFontFormatIsCurrentlyBold()
        {
            //Arrange
            var italicsCommand = new Italics();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontFormat = FontFormat.Bold;

            var expectedValue = "</b><i>";

            //Act
            italicsCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontFormat.Italics, currentPdf.CurrentFontFormat);
        }
    }
}
