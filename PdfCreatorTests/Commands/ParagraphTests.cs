using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class ParagraphTests
    {
        [Test]
        public void ProcessAppendsClosingAndOpeningParagraphTagsToStringBuilder()
        {
            //Arrange
            var paragraphCommand = new Paragraph();
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();

            var expectedValue = "</p><p>";

            //Act
            paragraphCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
        }
    }
}
