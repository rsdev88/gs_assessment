using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using PdfCreator;
using PdfCreator.Commands;
using PdfCreator.PdfGenerators;
using System;
using System.Collections.Generic;

namespace PdfCreatorTests.PdfGenerators
{
    [TestFixture]
    public class PdfGeneratorTests
    {
        private Mock<IConfiguration> configuration;
        private Mock<IConfigurationSection> configurationSection;

        [SetUp]
        public void PdfGeneratorTests_Setup()
        {
            this.configuration = new Mock<IConfiguration>();
            this.configurationSection = new Mock<IConfigurationSection>();
        }

        [Test]
        public void BuildPdfShouldThrowErrorWithNullInput()
        {
            //Arrange
            this.configurationSection.Setup(cs => cs.Value).Returns("fakeoutput");
            this.configuration.Setup(c => c.GetSection(It.IsAny<string>())).Returns(configurationSection.Object);

            var expectedErrorMessage = Constants.NO_COMMANDS_TO_PROCESS_ERROR;

            var pdfGenerator = new PdfGenerator(configuration.Object);

            //Act (see Assertion)

            //Assert
            var error = Assert.Throws<ArgumentException>(() => pdfGenerator.BuildPdf(null));
            Assert.AreEqual(expectedErrorMessage, error.Message);
        }

        [Test]
        public void BuildPdfShouldThrowErrorWithEmptyInput()
        {
            //Arrange
            this.configurationSection.Setup(cs => cs.Value).Returns("fakeoutput");
            this.configuration.Setup(c => c.GetSection(It.IsAny<string>())).Returns(configurationSection.Object);

            var expectedErrorMessage = Constants.NO_COMMANDS_TO_PROCESS_ERROR;

            var commands = new Queue<ICommand>();
            var pdfGenerator = new PdfGenerator(configuration.Object);

            //Act (see Assertion)

            //Assert
            var error = Assert.Throws<ArgumentException>(() => pdfGenerator.BuildPdf(commands));
            Assert.AreEqual(expectedErrorMessage, error.Message);
        }
    }
}
