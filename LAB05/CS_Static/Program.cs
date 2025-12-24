using System;
using System.Text;

namespace CS_Static
{
    public class Matrix
    {
        private int _rows;
        private int _cols;
        private double[,] _data;

        public int Rows => _rows;
        public int Cols => _cols;

        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Размерность матрицы должна быть положительной.");

            _rows = rows;
            _cols = cols;
            _data = new double[rows, cols];
        }

        public double this[int r, int c]
        {
            get
            {
                ValidateIndices(r, c);
                return _data[r, c];
            }
            set
            {
                ValidateIndices(r, c);
                _data[r, c] = value;
            }
        }

        private void ValidateIndices(int r, int c)
        {
            if (r < 0 || r >= _rows || c < 0 || c >= _cols)
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
        }

        public void Randomize(int min, int max)
        {
            Random rnd = new Random();
            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _cols; j++)
                    _data[i, j] = rnd.Next(min, max);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Для сложения размеры матриц должны совпадать.");

            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    res[i, j] = a[i, j] + b[i, j];
            return res;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Для вычитания размеры матриц должны совпадать.");

            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    res[i, j] = a[i, j] - b[i, j];
            return res;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй.");

            Matrix res = new Matrix(a.Rows, b.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Cols; j++)
                {
                    for (int k = 0; k < a.Cols; k++)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;
        }

        public static Matrix operator /(Matrix a, double divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Нельзя делить матрицу на ноль.");

            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    res[i, j] = a[i, j] / divisor;
            return res;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Matrix ({_rows}x{_cols}):");
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    sb.Append($"{_data[i, j],6:F1} ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix other)
            {
                return (this.Rows * this.Cols) == (other.Rows * other.Cols);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (_rows * _cols).GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Тестирование класса Matrix ===\n");

            Matrix m1 = new Matrix(2, 3);
            m1.Randomize(1, 10);
            Console.WriteLine("Матрица 1:");
            Console.WriteLine(m1.ToString());

            Matrix m2 = new Matrix(2, 3);
            m2.Randomize(1, 10);
            Console.WriteLine("Матрица 2:");
            Console.WriteLine(m2.ToString());

            Console.WriteLine("Сумма (m1 + m2):");
            Console.WriteLine((m1 + m2).ToString());

            Console.WriteLine("Разность (m1 - m2):");
            Console.WriteLine((m1 - m2).ToString());

            Console.WriteLine("Деление m1 на 2:");
            Console.WriteLine((m1 / 2.0).ToString());

            Matrix m3 = new Matrix(3, 2);
            m3.Randomize(1, 5);
            Console.WriteLine("Матрица 3 (для умножения на m1):");
            Console.WriteLine(m3.ToString());

            Console.WriteLine("Умножение (m1 * m3):");
            try 
            {
                Console.WriteLine((m1 * m3).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine($"m1 Equals m2 (по кол-ву элементов)? -> {m1.Equals(m2)}");
            
            Matrix m4 = new Matrix(6, 1);
            Console.WriteLine($"m1 (2x3) Equals m4 (6x1)? -> {m1.Equals(m4)}");

            Matrix m5 = new Matrix(2, 2);
            Console.WriteLine($"m1 Equals m5 (2x2)? -> {m1.Equals(m5)}");

            Console.ReadLine();
        }
    }
}