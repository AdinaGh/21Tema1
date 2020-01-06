using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tema1;

namespace Tema1Tests
{
    [TestClass]
    public class StringUtilsReverseTests
    {
        private StringUtils sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new StringUtils();
        }
        
        [TestMethod]
        [DataRow("ab-cd", "dc-ba")]
        [DataRow("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
        [DataRow("Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!")]
        public void Should_Reverse_A_Valid_String(string input, string expected)
        {
            //Arrange

            //Act
            string actual = sut.Reverse(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_Throw_Exception_When_Empty()
        {
            //Arrange
            string input = "";

            StringUtils sut = new StringUtils();

            //Act
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Reverse(input));

        }
    }
}
