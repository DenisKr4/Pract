using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix;

            Console.Write("Введите число строк: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Введите число столбцов: ");
            int column = int.Parse(Console.ReadLine());

            matrix = new MyMatrix(row, column);

            matrix.FillMatrix();
            matrix.OutputMatrix();

            Console.ReadKey();
        }

        private class MyMatrix
        {
            private int _rowCount;
            private int _colCount;
            private int[,] _matrix;

            public MyMatrix(int row, int column)
            {
                _rowCount = row;
                _colCount = column;
                _matrix = new int[row, column];
            }

            public void FillMatrix()
            {
                for(int i = 0; i < _rowCount; i++)
                {
                    Console.WriteLine("Введите строку матрицы №{0}:", i + 1);
                    for (int j = 0; j < _colCount; j++)
                    {
                        Console.Write("{0} число: ", j + 1);
                        _matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }

            public void OutputMatrix()
            {
                Console.WriteLine("\nИтоговая матрица:");
                for (int i = 0; i < _rowCount; i++)
                {
                    Console.WriteLine("");
                    for(int  j = 0; j < _colCount; j++)
                    {
                        Console.Write("{0} ", _matrix[i, j]);
                    }
                }
            }
        }
    }
}
