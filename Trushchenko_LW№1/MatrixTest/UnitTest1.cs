using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Trushchenko_LW_1;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_WithValidArguments_InitializesMatrix()
        {
            // Arrange
            int rows = 3;
            int columns = 4;
            int[,] data = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            // Act
            Matrix matrix = new Matrix(rows, columns, data);

            // Assert
            Assert.IsNotNull(matrix);
            Assert.AreEqual(rows, matrix.Rows);
            Assert.AreEqual(columns, matrix.Columns);
            // Add more assertions to verify the initialization of the matrix data.
        }

        [TestMethod]
        public void Multiply_ByScalar_ReturnsCorrectResult()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            int[,] data = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            Matrix matrix = new Matrix(rows, columns, data);
            int scalar = 2;
            Matrix expected = new Matrix(2, 2, new int[,] { { 2, 4 }, { 6, 8 } });

            // Act
            Matrix result = matrix.Multiply(scalar);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_TwoMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            int[,] data1 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int[,] data2 = new int[2, 2] { { 5, 6 }, { 7, 8 } };
            Matrix matrix1 = new Matrix(rows, columns, data1);
            Matrix matrix2 = new Matrix(rows, columns, data2);
            Matrix expected = new Matrix(2, 2, new int[,] { { 6, 8 }, { 10, 12 } });

            // Act
            Matrix result = matrix1.Add(matrix2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Equals_CompareMatrices_ReturnsTrueIfEqual()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            int[,] data1 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int[,] data2 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            Matrix matrix1 = new Matrix(rows, columns, data1);
            Matrix matrix2 = new Matrix(rows, columns, data2);

            // Act
            bool result = matrix1.Equals(matrix2);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Equals_CompareMatrices_ReturnsFalseIfNotEqual()
        {
            // Arrange
            int rows = 2;
            int columns = 2;
            int[,] data1 = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int[,] data2 = new int[2, 2] { { 1, 2 }, { 4, 3 } };
            Matrix matrix1 = new Matrix(rows, columns, data1);
            Matrix matrix2 = new Matrix(rows, columns, data2);

            // Act
            bool result = matrix1.Equals(matrix2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Multiply_TwoMatrices_ReturnsCorrectResult()
        {
            // Arrange
            int rows1 = 2;
            int columns1 = 3;
            int[,] data1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Matrix matrix1 = new Matrix(rows1, columns1, data1);

            int rows2 = 3;
            int columns2 = 2;
            int[,] data2 = new int[3, 2] { { 7, 8 }, { 9, 10 }, { 11, 12 } };
            Matrix matrix2 = new Matrix(rows2, columns2, data2);

            Matrix expected = new Matrix(2, 2, new int[,] { { 58, 64 }, { 139, 154 } });

            // Act
            Matrix result = matrix1.Multiply(matrix2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Transpose_Matrix_ReturnsTransposedMatrix()
        {
            // Arrange
            int rows = 3;
            int columns = 2;
            int[,] data = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            Matrix matrix = new Matrix(rows, columns, data);

            Matrix expected = new Matrix(2, 3, new int[,] { { 1, 3, 5 }, { 2, 4, 6 } });

            // Act
            Matrix result = matrix.Transpose();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

