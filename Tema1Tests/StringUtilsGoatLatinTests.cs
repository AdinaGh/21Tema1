using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tema1;

namespace Tema1Tests
{
    [TestClass]
    public class StringUtilsGoatLatinTests
    {
        private StringUtils sut;

        [TestInitialize]
        public void Setup()
        {
            sut = new StringUtils();
        }

        [TestMethod]
        [DataRow("I speak Goat Latin", "Imaa peaksmaaa oatGmaaaa atinLmaaaaa")]
        [DataRow("The quick brown fox jumped over the lazy dog", "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa")]
        public void Should_Reverse_A_Valid_String(string input, string expected)
        {
            //Arrange

            //Act
            string actual = sut.GoatLatin(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
