using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tema1;

namespace Tema1Tests
{
    [TestClass]
    public class MatrixMultiplyTests
    {
        [TestMethod]
        public void Should_Multiply_TwoDouble_Valid_Matrix()
        {
            //Arrange
            var mat1 = new Matrix<double>(2, 1);
            mat1[0, 0] = 1;
            mat1[1, 0] = 2.0;
            var mat2 = new Matrix<double>(1, 3);
            mat2[0, 0] = 3;
            mat2[0, 1] = 4;
            mat2[0, 2] = 5.0;

            //Act
            var mult = mat1 * mat2;

            //Assert
            Assert.IsNotNull(mult.Elements);
            Assert.AreEqual(6, mult.Elements.Length);
            Assert.AreEqual(2, mult.Elements?.GetLength(0) ?? 0);
            Assert.AreEqual(3, mult.Elements?.GetLength(1) ?? 0);
            Assert.AreEqual(typeof(Matrix<double>), mult.GetType());

            Assert.AreEqual(mult.Elements[0, 0], 3);
            Assert.AreEqual(mult.Elements[0, 1], 4);
            Assert.AreEqual(mult.Elements[0, 2], 5);
            Assert.AreEqual(mult.Elements[1, 0], 6);
            Assert.AreEqual(mult.Elements[1, 1], 8);
            Assert.AreEqual(mult.Elements[1, 2], 10);
        }

        [TestMethod]
        public void Should_Throw_Exception_When_RowsNotEqualColumns()
        {
            //Arrange
            var mat1 = new Matrix<double>(2, 1);
            mat1[0, 0] = 1;
            mat1[1, 0] = 2;
            var mat2 = new Matrix<double>(2, 3);
            mat2[0, 2] = 5;

            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => mat1 * mat2);
        }

        [TestMethod]
        public void Should_Return_SingleElement_ZeroValue()
        {
            //Arrange
            var mat1 = new Matrix<double>(1, 2);
            var mat2 = new Matrix<double>(2, 1);
            var mult = mat1 * mat2;
            Assert.IsNotNull(mult.Elements);
            Assert.AreEqual(1, mult.Elements.Length);
            Assert.AreEqual(1, mult.Elements?.GetLength(0) ?? 0);
            Assert.AreEqual(1, mult.Elements?.GetLength(1) ?? 0);
            Assert.AreEqual(typeof(Matrix<double>), mult.GetType());

            Assert.AreEqual(mult.Elements[0, 0], 0);
        }

        [TestMethod]
        public void Should_Multiply_TwoInt_Valid_Matrix()
        {
            //Arrange
            var mat1 = new Matrix<int>(2, 1);
            mat1[0, 0] = 1;
            mat1[1, 0] = 2;
            var mat2 = new Matrix<int>(1, 3);
            mat2[0, 0] = 3;
            mat2[0, 1] = 4;
            mat2[0, 2] = 5;

            //Act
            var mult = mat1 * mat2;

            //Assert
            Assert.IsNotNull(mult.Elements);
            Assert.AreEqual(6, mult.Elements.Length);
            Assert.AreEqual(2, mult.Elements?.GetLength(0) ?? 0);
            Assert.AreEqual(3, mult.Elements?.GetLength(1) ?? 0);
            Assert.AreEqual(typeof(Matrix<int>), mult.GetType());

            Assert.AreEqual(mult.Elements[0, 0], 3);
            Assert.AreEqual(mult.Elements[0, 1], 4);
            Assert.AreEqual(mult.Elements[0, 2], 5);
            Assert.AreEqual(mult.Elements[1, 0], 6);
            Assert.AreEqual(mult.Elements[1, 1], 8);
            Assert.AreEqual(mult.Elements[1, 2], 10);

        }
    }
}
