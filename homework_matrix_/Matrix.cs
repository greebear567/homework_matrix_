using System;
using System.Collections.Generic;
using System.Text;

namespace homework_matrix_
{
    class Matrix
    {
        //поля и свойства
        public double[,] arr
        {
            get;
            set;
        }

        //конструкторы

        public Matrix (Matrix matr)
        {
            arr = matr.arr;
        }
        public Matrix()
        {
        }
        public Matrix(double[,] arr1)
        {
            arr = arr1;
        }

        public Matrix(int str, int sto)
        {
            arr = new double[str, sto];
            int k = 0;
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < sto; j++)
                {
                    arr[i, j] = k++;
                }
            }
        }

        //методы
        static public Matrix operator +(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr1.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        res[i, j] = matr1.arr[i, j] + matr2.arr[i, j];
                    }
                }
                return new Matrix(res);
            }
            else {throw new Exception("У матриц разная размерность(+)");}
        }

        static public Matrix operator -(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr1.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        res[i, j] = matr1.arr[i, j] - matr2.arr[i, j];
                    }
                }
                return new Matrix(res);
            }
            else { throw new Exception("У матриц разная размерность(-)"); }
        }

        static public Matrix operator *(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(1))
            {
                double[,] res = new double[matr1.arr.GetLength(0), matr2.arr.GetLength(1)];
                for (int i = 0; i < matr1.arr.GetLength(0); i++) //i - stroku matr1
                {
                    for (int h = 0; h < matr2.arr.GetLength(1); h++) // h - stolbci matr2
                    {
                        for (int j = 0; j < matr1.arr.GetLength(1); j++)
                        {
                            res[i, h] += matr1.arr[i, j] * matr2.arr[j, h];
                        }
                    }
                }
                return new Matrix(res);
            }
            else {throw new Exception("У матриц неправильные размерности(*)");}
        }

        static public Matrix operator /(Matrix matr, double k)
        {
            if (k == 0) throw new Exception("Нельзя делить на ноль");
            double[,] res = new double[matr.arr.GetLength(0), matr.arr.GetLength(1)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(1); j++)
                {
                    res[i, j] = matr.arr[i, j] / k;
                }
            }
            return new Matrix(res);
        }

        static public Matrix operator ~(Matrix matr)
        {
            double[,] res = new double[matr.arr.GetLength(1), matr.arr.GetLength(0)];
            for (int i = 0; i < matr.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.arr.GetLength(1); j++)
                {
                    res[j, i] = matr.arr[i, j];
                }
            }
            return new Matrix(res);
        }

        //операторы сравнения на равенство 

        static public bool operator ==(Matrix matr1, Matrix matr2)
        {
            if (matr1.arr.GetLength(0) == matr2.arr.GetLength(0) && matr1.arr.GetLength(1) == matr2.arr.GetLength(1))
            {
                for (int i = 0; i < matr1.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr1.arr.GetLength(1); j++)
                    {
                        if (matr1.arr[i, j] != matr2.arr[i, j]) return false;
                    }
                }
            }
            else return false;
            return true;
        }

        static public bool operator !=(Matrix matr1, Matrix matr2)
        {
            if (matr1 == matr2) { return false; } else return true;
        }

        public override int GetHashCode()
        {
            //double[,] matr = new double[arr.GetLength(0),arr.GetLength(1)];
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        matr[i, j] = arr[i, j].GetHashCode();
            //    }
            //}
            return arr.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == arr)
                return true;
            else return false;
        }

        public override string ToString()
        {
            StringBuilder matr = new StringBuilder();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    matr.Append($"{arr[i, j]} \t");
                }
                matr.Append("\n");
            }
            return matr.ToString();
        }
    }
}
