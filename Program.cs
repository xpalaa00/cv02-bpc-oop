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

            try { Console.WriteLine("MatA + MatB:\n{0}", (A + B)); } catch { }
            try { Console.WriteLine("-MatA:\n{0}", -A); } catch { }
            try { Console.WriteLine("MatA - MatB:\n{0}", (A - B)); } catch { }
            try { Console.WriteLine("MatA * MatB:\n{0}", (A * B)); } catch { }
            double multiplier = ((randGen.Next(200) / 10.0) - 10.0);
            try { Console.WriteLine("MatA * {0}:\n{1}", multiplier, A * multiplier); } catch { }
            try { Console.WriteLine("MatA == MatB: {0}", (A == B)); } catch { }
            try { Console.WriteLine("MatA != MatB: {0}", (A != B)); } catch { }
            try { Console.WriteLine("Det(MatA): {0:f4}", A.Det()); } catch { }
            try { Console.WriteLine("Det(MatB): {0:f4}", B.Det()); } catch { }

            Console.ReadLine();
        }
    }
}
