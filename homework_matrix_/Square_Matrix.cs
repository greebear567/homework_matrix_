using System;
using System.Collections.Generic;
using System.Text;

namespace homework_matrix_
{
    class Square_Matrix : Matrix
    {
        public Square_Matrix(Square_Matrix matr)
        {
            arr = matr.arr;
        }
        public Square_Matrix()
        {
            arr = new double[1, 1];
            arr[0, 0] = 0;
        }
        public Square_Matrix(Matrix matr)
        {
            if (matr.arr.GetLength(0) != matr.arr.GetLength(1)) throw new Exception("Матрица не квадратная");
            
            arr = new double[matr.arr.GetLength(0), matr.arr.GetLength(0)];
            arr = matr.arr;
        }

        public Square_Matrix(int dim1)
        {
            arr = new double[dim1, dim1];
            int k = 0;
            for (int i = 0; i < dim1; i++)
            {
                for (int j = 0; j < dim1; j++)
                {
                    arr[i, j] = k++;
                }
            }
        }
        
        public Square_Matrix(double[,] some)
        {
            if (some.GetLength(0) != some.GetLength(1)) throw new Exception("Матрица не квадратная(2)");
            arr = some;
        }

        public double minor(double[,] matr, int num_sto, int num_str)
        {
            double[,] matr_1 = new double[matr.GetLength(0)-1, matr.GetLength(0)-1];
            for (int i = 0; i < num_str; i++)
            {
                for (int j = 0; j < num_sto; j++)
                {
                    matr_1[i, j] = matr[i, j];
                }
                for (int j = matr.GetLength(0)-1; j > num_sto; j--)
                {
                    matr_1[i, j - 1] = matr[i, j];
                }
            }
            for (int i = matr.GetLength(0)-1; i > num_str; i--)
            {
                for (int j = 0; j < num_sto; j++)
                {
                    matr_1[i - 1, j] = matr[i, j];
                }
                for (int j = matr.GetLength(0)-1; j > num_sto; j--)
                {
                    matr_1[i - 1, j - 1] = matr[i, j];
                }
            }
            return determinant(matr_1);
        }

        //double minor(double[,] matr,int num_sto,int dim)
        //{
        //    double[,] matr_1 = new double[dim,dim];
        //    for(int i = 1; i < dim+1; i++)
        //    {
        //        for(int j = 0; j < num_sto; j++)
        //        {
        //            matr_1[i-1, j] = matr[i,j];
        //        }
        //        for (int j = dim; j > num_sto; j--)
        //        {
        //            matr_1[i-1, j-1] = matr[i, j];
        //        }
        //    }
        //    return determinant(matr_1, dim);
        //}

        public double determinant(double[,] matr)
        {
            double result=0;
            if (matr.GetLength(0) != 2)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    if (i % 2 == 0)
                    {
                        result += matr[0,i]* minor(matr, i,0);
                    }
                    else
                    {
                        result -= matr[0,i]* minor(matr, i,0);
                    }
                }
                return result;
            }
            else return matr[0, 0] * matr[1, 1] - matr[1, 0] * matr[0, 1];
        }
    }


    class Obr_Matr : Square_Matrix
    {
        public Obr_Matr(double[,] matr)
        {
            arr = matr;
        }
        public Obr_Matr(Square_Matrix matr)
        {
            arr = matr.arr;
        }

        public Obr_Matr(Matrix matr)
        {
            arr = matr.arr;
        }

        public Obr_Matr(Obr_Matr matr)
        {
            arr = matr.arr;
        }
        

        public Square_Matrix Obr()
        {
            Square_Matrix res = new Square_Matrix(arr.GetLength(0));
            if (res.determinant(arr) == 0) throw new Exception("Определитель равен 0");
            Matrix per2 = new Matrix(arr);
            per2 = ~per2;
            Square_Matrix tran = new Square_Matrix(per2);
            for(int i = 0; i < tran.arr.GetLength(0); i++)
            {
                for(int j = 0; j < tran.arr.GetLength(0); j++)
                {
                    res.arr[i, j] = minor(tran.arr, j, i)/determinant(arr)*Math.Pow(-1,i+j);
                }
            }
            return res;
        }
    }
}