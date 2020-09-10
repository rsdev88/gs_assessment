using NUnit.Framework;
using PdfCreator.Commands;
using PdfCreator.InputMappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfCreatorTests.InputMappers
{
    public class InputMapperTests
    {

        private InputMapper inputMapper;

        [SetUp]
        public void InputMapper_Setup()
        {
            this.inputMapper = new InputMapper();
        }

        public void MapInputFromArrayThrowsErrorForNullnputArray()
        {
            //Arrange
            string[] inputArray = null;

            //Act (see Assertion)

            //Assert 
            Assert.Throws<ArgumentException>(() => this.inputMapper.MapInputFromArray(inputArray));
        }

        public void MapInputFromArrayThrowsErrorForEmptyInputArray()
        {
            //Arrange
            string[] inputArray = new string[0];

            //Act (see Assertion)

            //Assert 
            Assert.Throws<ArgumentException>(() => this.inputMapper.MapInputFromArray(inputArray));
        }

        [Test]
        public void MapInputFromArrayMapsCommandCorrectly_Text()
        {
            //Arrange
            var inputText = "Hello world!";
            var inputArray = new string[] { inputText };

            //Act
            var output = this.inputMapper.MapInputFromArray(inputArray);

            //Assert
            Assert.IsTrue(output != null);
            Assert.IsTrue(output.Count == 1);

            var firstCommand = output.Dequeue();
            Assert.IsTrue(firstCommand.GetType() == typeof(Text));

            var firstCommandAsText = firstCommand as Text;
            Assert.IsTrue(firstCommandAsText.Value == inputText);
        }


        [TestCase(".indent +2", 2)]
        [TestCase(".indent -2", -2)]
        [TestCase(".indent 0", 0)]
        public void MapInputFromArrayMapsCommandCorrectly_Indent(string inputText, int expectedIndentation)
        {
            //Arrange
            var inputArray = new string[] { inputText };

            //Act
            var output = this.inputMapper.MapInputFromArray(inputArray);

            //Assert
            Assert.IsTrue(output != null);
            Assert.IsTrue(output.Count == 1);

            var firstCommand = output.Dequeue();
            Assert.IsTrue(firstCommand.GetType() == typeof(Indent));

            var firstCommandAsIndent = firstCommand as Indent;
            Assert.IsTrue(firstCommandAsIndent.Indentation == expectedIndentation);
        }


        [TestCase(".large", typeof(Large))]
        [TestCase(".normal", typeof(Normal))]
        [TestCase(".paragraph", typeof(Paragraph))]
        [TestCase(".fill", typeof(Fill))]
        [TestCase(".nofill", typeof(NoFill))]
        [TestCase(".regular", typeof(Regular))]
        [TestCase(".italics", typeof(Italics))]
        [TestCase(".bold", typeof(Bold))]
        public void MapInputFromArrayMapsOtherCommandCorrectly(string inputText, Type expectedType)
        {
            //Arrange
            var inputArray = new string[] { inputText };

            //Act
            var output = this.inputMapper.MapInputFromArray(inputArray);

            //Assert
            Assert.IsTrue(output != null);
            Assert.IsTrue(output.Count == 1);

            var firstCommand = output.Dequeue();
            Assert.IsTrue(firstCommand.GetType() == expectedType);
        }
    }
}
