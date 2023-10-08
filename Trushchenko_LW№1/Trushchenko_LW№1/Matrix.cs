using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trushchenko_LW_1
{
    public class Matrix : IMatrix
    {
        private int[,] data;

        public int Count { get => throw new NotImplementedException(); private set => throw new NotImplementedException(); }

        private int _rows;
        public int Rows
        {
            get => _rows;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of rows must be > 0");
                }
                _rows = value;
            }
        }
        private int _columns;
        public int Columns
        {
            get => _columns;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of columns must be > 0");
                }
                _columns = value;
            }
        }

        public Matrix(int rows, int columns, int[,] initialData)
        {
            Rows = rows;
            Columns = columns;

            if (initialData == null)
            {
                throw new ArgumentNullException(nameof(initialData), "Initial data cannot be null.");
            }

            if (initialData.GetLength(0) != Rows || initialData.GetLength(1) != Columns)
            {
                throw new ArgumentException("Initial data dimensions do not match the specified matrix dimensions.");
            }

            data = initialData;
        }

        // Конструктор за розмірами матриці
        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            data = new int[rows, columns];
        }

        // Конструктор з двовимірним масивом
        public Matrix(int[,] array)
        {
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
            data = new int[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    data[i, j] = array[i, j];
                }
            }
        }

        // Конструктор з одновимірним масивом
        public Matrix(int[] array)
        {
            Rows = 1;
            Columns = array.Length;
            data = new int[1, Columns];

            for (int j = 0; j < Columns; j++)
            {
                data[0, j] = array[j];
            }
        }

        // Функція порівняння об'єктів на рівність
        public bool AreEqual(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix other = (Matrix)obj;

            if (this.Rows != other.Rows || this.Columns != other.Columns)
                return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this.data[i, j] != other.data[i, j])
                        return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;

            Matrix other = (Matrix)obj;

            if (this.Rows != other.Rows || this.Columns != other.Columns)
                return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this.data[i, j] != other.data[i, j])
                        return false;
                }
            }

            return true;
        }

        // Функція введення з консолі
        public static Matrix InputFromConsole()
        {
            Console.Write("Введіть кількість рядків: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість стовпців: ");
            int columns = int.Parse(Console.ReadLine());

            Matrix matrix = new Matrix(rows, columns);

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"matrix[{i}, {j}] = ");
                    matrix.data[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        // Перевизначена функція ToString
        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result += data[i, j] + "\t";
                }
                result += "\n";
            }

            return result;
        }

        // Функція для додавання двох матриць
        public Matrix Add(Matrix other)
        {
            if (this.Rows != other.Rows || this.Columns != other.Columns)
                throw new ArgumentException("Розміри матриць не відповідають");

            Matrix result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.data[i, j] = this.data[i, j] + other.data[i, j];
                }
            }

            return result;
        }

        // Функція для множення матриці на число
        public Matrix Multiply(int scalar)
        {
            Matrix result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.data[i, j] = this.data[i, j] * scalar;
                }
            }

            return result;
        }

        // Функція для множення двох матриць
        public Matrix Multiply(Matrix other)
        {
            if (this.Columns != other.Rows)
                throw new ArgumentException("Розміри матриць не відповідають для множення");

            Matrix result = new Matrix(this.Rows, other.Columns);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < other.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < this.Columns; k++)
                    {
                        sum += this.data[i, k] * other.data[k, j];
                    }
                    result.data[i, j] = sum;
                }
            }

            return result;
        }

        // Функція для транспонування матриці
        public Matrix Transpose()
        {
            Matrix result = new Matrix(Columns, Rows);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result.data[j, i] = this.data[i, j];
                }
            }

            return result;
        }

        public int this[int row, int column]
        {
            get
            {
                // Отримання значення елемента матриці за індексами row та column
                return data[row, column];
            }
            set
            {
                // Встановлення значення елемента матриці за індексами row та column
                data[row, column] = value;
            }
        }
    }
}
