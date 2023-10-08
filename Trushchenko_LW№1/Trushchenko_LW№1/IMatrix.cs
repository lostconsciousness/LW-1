using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trushchenko_LW_1
{
    public interface IMatrix
    {
        int Count { get; }
        int Rows { get; }
        int Columns { get; }

        Matrix Add(Matrix other);
        Matrix Multiply(int scalar);
        Matrix Multiply(Matrix other);
        Matrix Transpose();

        // Властивість для доступу до елементів матриці
        int this[int row, int column] { get; set; }
    }
}
