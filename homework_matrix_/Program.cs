using System;

namespace homework_matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[,] mat = new double[,] { { 1,1,1}, { 2,3,2 } };
            //double[,] mat1 = new double[,] { { 0,2}, { 5,1}, { 1, 3 } };
            //Matrix matr = new Matrix(mat);
            //Matrix matr1 = new Matrix(mat1);
            //Console.WriteLine(matr);
            //Console.WriteLine(matr1);
            //Console.WriteLine("Сложение\n{0}", matr + matr1);
            //Console.WriteLine("Вычитание\n {0}", matr - matr1);
            //Console.WriteLine("Умножение\n {0}", matr * matr1);
            //Console.WriteLine("Деление на 2\n{0}", matr / 2);
            //Console.WriteLine("Транспонирование\n{0}",~matr);
            //Console.WriteLine("Транспонирование\n{0}",~matr1);
            //Console.WriteLine("Матрица 1 = матрица 2 - {0}", matr == matr1);
            //Console.WriteLine("Матрица 1 != матрица 2 - {0}", matr != matr1);
            // double[,] array2D = new double[,] { { 5,6,7 }, { 8,9,3 }, { 2,5,7 } };
            //double[,] array2D = new double[,] { { 5, 0, 0 }, { 0, 9, 3 }, { 0, 5, 7 } };
            double[,] array2D = new double[,] { {1,2,3,4}, {9,6,7,1 }, { 4,3,7,9 }, { 4, 2, 9, 5 } };
            Square_Matrix sq_m = new Square_Matrix(array2D);
            Console.WriteLine("Определитель {0}", sq_m.determinant(sq_m.arr));
            Obr_Matr prim = new Obr_Matr(sq_m);
            Console.WriteLine("Обратная матрица\n{0}", prim.Obr());
        }
    }
}
