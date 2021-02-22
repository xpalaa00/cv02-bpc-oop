using System;

namespace cv02_bpc_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randGen = new Random((int)DateTime.Now.Ticks);

            double[,] randMat = new double[3, 3];
            for(int i = 0; i < randMat.GetLength(0); i ++)
            {
                for(int j = 0; j < randMat.GetLength(1); j ++)
                {
                    randMat[i, j] = randGen.Next(200) / 10.0 - 10.0;
                }
            }
            Matrix A = new Matrix(randMat);

            randMat = new double[3, 3];
            for (int i = 0; i < randMat.GetLength(0); i++)
            {
                for (int j = 0; j < randMat.GetLength(1); j++)
                {
                    randMat[i, j] = randGen.Next(200) / 10.0 - 10.0;
                }
            }
            Matrix B = new Matrix(randMat);

            Console.WriteLine("MatA + MatB:\n{0}", (A + B));
            Console.WriteLine("-MatA:\n{0}", -A);
            Console.WriteLine("MatA - MatB:\n{0}", (A - B));
            Console.WriteLine("MatA * MatB:\n{0}", (A * B));
            double multiplier = ((randGen.Next(200) / 10.0) - 10.0);
            Console.WriteLine("MatA * {0}:\n{1}", multiplier, A * multiplier);
            Console.WriteLine("MatA == MatB: {0}", (A == B));
            Console.WriteLine("MatA != MatB: {0}", (A != B));
            Console.WriteLine("Det(MatA): {0:f4}", A.Det());
            Console.WriteLine("Det(MatB): {0:f4}", B.Det());

            Console.ReadLine();
        }
    }
}
