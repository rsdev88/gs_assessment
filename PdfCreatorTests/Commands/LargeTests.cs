using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class LargeTests
    {
        [Test]
        public void ProcessAppendsToStringBuilderUsingClosingFontTagAndAdjustSize()
        {
            //Arrange
            var largeCommand = new Large();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontSize = FontSize.Normal;

            var expectedValue = string.Format("</font><font pointSize='{0}'>", (int)FontSize.Large);

            //Act
            largeCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontSize.Large, currentPdf.CurrentFontSize);
        }

        [Test]
        public void ProcessDoesNotCloseFontTagIfSizeIsAlreadyLarge()
        {
            //Arrange
            var largeCommand = new Large();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();
            currentPdf.CurrentFontSize = FontSize.Large;

            var expectedValue = string.Format("<font pointSize='{0}'>", (int)FontSize.Large);

            //Act
            largeCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
            Assert.AreEqual(FontSize.Large, currentPdf.CurrentFontSize);
        }
    }
}
