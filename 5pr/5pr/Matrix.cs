using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5pr
{
    internal class Matrix
    {
        private int m;
        private int[,] mass;

        // конструкторы матрицы
        public Matrix() { }
        public int M
        {
            get { return m; }
            set { if (value > 0) m = value; }
        }

        
        public Matrix(int m)
        {
            this.m = m;
            mass = new int[this.m, this.m];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        // Ввод матрицы
        public void InputMatrix()
        {
            Random r = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public void ReadMatrix()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        // Проверка на единичность
        public void Singularity(Matrix a)
        {
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] == 1 && i == j)
                    {
                        count++;
                    }
                }

            }
            if (count == a.M)
            {
                Console.WriteLine("Единичная");
            }
            else Console.WriteLine("Не единичная");
        }
        // Умножение матрицы на число
        public static Matrix multiplication(Matrix a, int ch)
        {
            Matrix resMass = new Matrix(a.M);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    resMass[i, j] += a[i, j] * ch;
                }
            }
            return resMass;
        }

        // Умножение матрицы на матрицу 
        public static Matrix multiplication2(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M);
            for (int i = 0; i < a.M; i++)
                for (int j = 0; j < b.M; j++)
                    for (int k = 0; k < b.M; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }
        //единичная матрица
        public Matrix Identity_matrix()
        {
            Matrix unitMatrix = new Matrix(m);

            for (int i = 0; i < m; i++)
                for (int j = 0; j < m; j++)
                {
                    if (i == j)
                        unitMatrix[i, j] = 1;
                    else
                        unitMatrix[i, j] = 0;
                }
            return unitMatrix;
        }

        // проверка на связность
        public string Connectedness(Matrix reachabilityMatrix)
        {
            int t = 1;

            for (int i = 0; i < reachabilityMatrix.M; i++)
                for (int j = 0; j < reachabilityMatrix.M; j++)
                    if (reachabilityMatrix[i, j] == 0)
                    {
                        t = 0;
                        break;
                    }

            if (t == 1)
                return "Граф является связным";
            else
                return "Граф не является связным";

        }

        // матрица достижимости
        public Matrix Reachability(Matrix matrix)
        {
            Matrix reachabilityMatrix = new Matrix(m);
            reachabilityMatrix = reachabilityMatrix.Identity_matrix();

            for (int i = 1; i < m; i++)
            {
                Matrix value = new Matrix(m);
                value = matrix;

                for (int j = 0; j < i; j++)
                    value = value * matrix;

                reachabilityMatrix = reachabilityMatrix + value;
            }

            reachabilityMatrix = reachabilityMatrix.BooleanMatrix(reachabilityMatrix);
            return reachabilityMatrix;
        }

        // создание булевой матрицы
        public Matrix BooleanMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.m; i++)
                for (int j = 0; j < matrix.m; j++)
                {
                    if (matrix[i, j] != 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;
                }

            return matrix;
        }

        
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.multiplication2(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.multiplication(a, b);
        }


        // вычитаниt матрицы  из матрицы 
        public static Matrix Subtraction(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < b.M; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.Subtraction(a, b);
        }
        public static Matrix Addition(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.M);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < b.M; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Addition(a, b);
        }
        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }
    }
}
    

