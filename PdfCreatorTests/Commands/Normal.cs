using NUnit.Framework;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class Normal
    {
        [Test]
        public void ProcessAppendsToStringBuilderUsingClosingFontTagAndAdjustSize()
        {
            //Arrange
            var normalCommand = new PdfCreator.Commands.Normal();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontSize = FontSize.Large;

            var expectedValue = string.Format("</font><font pointSize='{0}'>", (int)FontSize.Normal);

            //Act
            normalCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontSize.Normal, currentPdf.CurrentFontSize);
        }

        [Test]
        public void ProcessDoesNotCloseFontTagIfSizeIsAlreadyNormal()
        {
            //Arrange
            var normalCommand = new PdfCreator.Commands.Normal();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontSize = FontSize.Normal;

            var expectedValue = string.Format("<font pointSize='{0}'>", (int)FontSize.Normal);

            //Act
            normalCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontSize.Normal, currentPdf.CurrentFontSize);
        }
    }
}
