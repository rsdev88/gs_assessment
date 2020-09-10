using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using PdfCreator;
using PdfCreator.FileReaders;
using PdfCreator.InputMappers;

namespace PdfCreatorTests.FileReaders
{
    [TestFixture]
    public class FileReaderTests
    {
        private Mock<IConfiguration> configuration;
        private Mock<IConfigurationSection> configurationSection;
        private Mock<IMapper> inputMapper;

        [SetUp]
        public void FileReaderTests_Setup()
        {
            this.configuration = new Mock<IConfiguration>();
            this.configurationSection = new Mock<IConfigurationSection>();
            this.inputMapper = new Mock<IMapper>();
        }

        [Test]
        public void ReadInput_ThrowsErrorIfInputFileIsNotFound()
        {
            //Arrange
            this.configurationSection.Setup(cs => cs.Value).Returns("fakefile.txt");
            this.configuration.Setup(c => c.GetSection(It.IsAny<string>())).Returns(configurationSection.Object);

            var fileReader = new FileReader(configuration.Object, inputMapper.Object);

            //Act (see Assertion)

            //Assert
            Assert.Throws<FileNotFoundException>(() => fileReader.ReadInput());
        }

        [Test]
        public void ReadInput_ThrowsErrorIfInputFileIsEmpty()
        {
            //Arrange
            var inputFileLocation = "../../../TestInputFiles/EmptyInput.txt";
            this.configurationSection.Setup(cs => cs.Value).Returns(inputFileLocation);
            this.configuration.Setup(c => c.GetSection(It.IsAny<string>())).Returns(configurationSection.Object);

            var expectedErrorMessage = string.Format(Constants.EMPTY_INPUT_ERROR, inputFileLocation);

            var fileReader = new FileReader(configuration.Object, inputMapper.Object);

            //Act (see Assertion)

            //Assert
            var error = Assert.Throws<FormatException>(() => fileReader.ReadInput());
            Assert.AreEqual(expectedErrorMessage, error.Message);
        }
    }
}
