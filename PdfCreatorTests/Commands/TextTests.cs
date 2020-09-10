using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System.Text;

namespace PdfCreatorTests.Commands
{
    [TestFixture]
    public class TextTests
    {
        [Test]
        public void ProcessAppendsToStringBuilder()
        {
            //Arrange
            var value = "Hello world!";
            var textCommand = new Text(value);
            var currentPdf = new CurrentPdf();
            currentPdf.StringBuilder = new StringBuilder();

            var expectedValue = value + " ";

            //Act
            textCommand.Process(ref currentPdf);

            //Assert
            Assert.AreEqual(expectedValue, currentPdf.StringBuilder.ToString());
        }
    }
}
