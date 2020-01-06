using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Matrix<T>
    {
        public Matrix(int rows, int columns)
        {
            Elements = new T[rows, columns];
        }
        public T[,] Elements { get; set; }

        public T this[int row, int column]
        {
            get
            {
                ValidateIndex(row, column);
                return Elements[row,column];
            }

            set
            {
                ValidateIndex(row, column);
                Elements[row,column] = value;
            }
        }

        private int RowsCount => Elements?.GetLength(0) ?? 0;

        private int ColumnsCount => Elements?.GetLength(1) ?? 0;

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            ValidateAddSub(matrix1, matrix2);
            dynamic result = new Matrix<T>(matrix1.RowsCount, matrix1.ColumnsCount);
            dynamic mat1 = matrix1;
            dynamic mat2 = matrix2;
            for (var i = 0; i < matrix1.RowsCount; i++)
            {
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    result[i, j] = mat1[i, j] + mat2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            ValidateAddSub(matrix1, matrix2);
            dynamic result = new Matrix<T>(matrix1.RowsCount, matrix1.ColumnsCount);
            dynamic mat1 = matrix1;
            dynamic mat2 = matrix2;
            for (var i = 0; i < matrix1.RowsCount; i++)
            {
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    result[i, j] = mat1[i, j] - mat2[i, j];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            ValidateMultiplication(matrix1, matrix2);
            dynamic result = new Matrix<T>(matrix1.RowsCount, matrix2.ColumnsCount);
            dynamic mat1 = matrix1;
            dynamic mat2 = matrix2;
            for (var i = 0; i < matrix1.RowsCount; i++)
            {
                for (var j = 0; j < matrix2.ColumnsCount; j++)
                {
                    dynamic sum = 0;
                    for (int k = 0; k < matrix1.ColumnsCount; k++)
                    {
                        sum += mat1[i, k] * mat2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (var i = 0; i < matrix.RowsCount; i++)
            {
                for (var j = 0; j < matrix.ColumnsCount; j++)
                {
                    if(matrix.Elements[i, j] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix<T> matrix)
        {
            for (var i = 0; i < matrix.RowsCount; i++)
            {
                for (var j = 0; j < matrix.ColumnsCount; j++)
                {
                    if (matrix.Elements[i,j] == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void ValidateMultiplication(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeMultiplcationErrorMessage(matrix2.RowsCount, matrix1.ColumnsCount));
            }
        }

        private static void ValidateAddSub(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.ColumnsCount || matrix1.RowsCount != matrix2.RowsCount)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeAddErrorMessage);
            }
        }

        private void ValidateIndex(int row, int column)
        {
            if (row < 0 || row >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeRowErrorMessage(RowsCount - 1));
            }
            if (column < 0 || column >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeColumnErrorMessage(ColumnsCount-1));
            }
        }

        private string OutOfRangeColumnErrorMessage(int length) => $"The column index is out of range [0-{length}]";
        private string OutOfRangeRowErrorMessage(int length) => $"The row index is out of range [0-{length}]";

        private static string OutOfRangeMultiplcationErrorMessage(int row, int column) => $"Invalid matrix dimensions for multiplication: {row} must be equal to {column}";
        private static string OutOfRangeAddErrorMessage => $"Invalid matrix dimensions for adding: they need to have the same dimension";

        public string Display()
        {
            var splitter = ",   ";
            var sb = new StringBuilder();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    sb.Append(Elements[i,j]+"");
                    if (j < ColumnsCount - 1)
                    {
                        sb.Append(splitter);                        
                    }
                }
                sb.AppendLine("\r\n");
            }


            return sb.ToString();
        }

    }
}
