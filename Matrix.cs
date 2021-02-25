using System;
using System.Text;

namespace cv02_bpc_oop
{
    class Matrix
    {
        public double[,] Mat;
        public static Matrix operator +(Matrix matA, Matrix matB)
        {
            //Ověřené platnosti rozměrů matic
            if (matA.Mat.GetLength(0) != matB.Mat.GetLength(0) ||
                matA.Mat.GetLength(1) != matB.Mat.GetLength(1))
            {
                throw new ArithmeticException("Matrixs' dimensions are not equal!");
            }

            //Rozměr X
            int dimX = matA.Mat.GetLength(0);
            //Rozměr Y
            int dimY = matA.Mat.GetLength(1);

            //Sečtení obou matic do nové matice
            double[,] workMat = new double[dimX, dimY];
            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    workMat[i, j] = matA.Mat[i, j] + matB.Mat[i, j];
                }
            }
            return new Matrix(workMat);
        }
        public static Matrix operator *(Matrix matA, Matrix matB)
        {
            //Ověřené platnosti rozměrů matic
            if (matA.Mat.GetLength(0) != matB.Mat.GetLength(1) ||
                matA.Mat.GetLength(1) != matB.Mat.GetLength(0))
            {
                throw new ArithmeticException("M dimension of matA is not equal to N dimension of matB or N dimension of matA is not equal to M dimension of matB");
            }

            //Určení výsledné velikosti matice
            //Rozměr X
            int dimX = matA.Mat.GetLength(0);
            //Rozměr Y
            int dimY = matB.Mat.GetLength(1);

            double[,] workMat = new double[dimX, dimY];
            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    for (int k = 0; k < matA.Mat.GetLength(1); k++)
                    {
                        workMat[i, j] = matA.Mat[i, k] * matB.Mat[k, j];
                    }
                }
            }
            return new Matrix(workMat);
        }
        public static Matrix operator *(Matrix matA, double multiplier)
        {
            //Určení výsledné velikosti matice
            //Rozměr X
            int dimX = matA.Mat.GetLength(0);
            //Rozměr Y
            int dimY = matA.Mat.GetLength(1);

            double[,] workMat = new double[dimX, dimY];
            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    workMat[i, j] = matA.Mat[i, j] * multiplier;
                }
            }
            return new Matrix(workMat);
        }
        public static Matrix operator *(double multiplier, Matrix matA)
        {
            return matA * multiplier;
        }
        public static Matrix operator -(Matrix matA)
        {
            return matA * (-1.0);
        }
        public static Matrix operator -(Matrix matA, Matrix matB)
        {
            return new Matrix((matA + (-matB)).Mat);
        }
        public static bool operator ==(Matrix matA, Matrix matB)
        {
            //Ověřené platnosti rozměrů matic
            if (matA.Mat.GetLength(0) != matB.Mat.GetLength(0) ||
                matA.Mat.GetLength(1) != matB.Mat.GetLength(1))
            {
                return false;
            }

            //Určení výsledné velikosti matice
            //Rozměr X
            int dimX = matA.Mat.GetLength(0);
            //Rozměr Y
            int dimY = matA.Mat.GetLength(1);

            for (int i = 0; i < dimX; i++)
            {
                for (int j = 0; j < dimY; j++)
                {
                    if (matA.Mat[i, j] != matB.Mat[i, j]) return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrix matA, Matrix matB)
        {
            return !(matA == matB);
        }
        public double Det()
        {
            //Ověřené platnosti rozměrů matic
            if (Mat.GetLength(0) != Mat.GetLength(1)) throw new ArithmeticException("Matrix is not square type!");
            else if (Mat.GetLength(0) > 3) throw new ArithmeticException("Matrix's dimensions are larger than 3!");

            //Určení velikosti matice
            int dimXY = Mat.GetLength(0);

            switch (dimXY)
            {
                case 1:
                    {
                        return Mat[0, 0];
                    }
                case 2:
                    {
                        return Mat[0, 0] * Mat[1, 1] - Mat[1, 0] * Mat[0, 1];
                    }
                case 3:
                    {
                        return  Mat[0, 0] * Mat[1, 1] * Mat[2, 2] +
                                Mat[1, 0] * Mat[2, 1] * Mat[0, 2] +
                                Mat[2, 0] * Mat[0, 1] * Mat[1, 2] -
                                Mat[2, 0] * Mat[1, 1] * Mat[0, 2] -
                                Mat[1, 0] * Mat[0, 1] * Mat[2, 2] -
                                Mat[0, 0] * Mat[2, 1] * Mat[1, 2];
                    }
                default:
                    {
                        return 0.0;
                    }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    output.AppendFormat("{0,6:f1}", Mat[i, j]);
                }
                output.AppendLine();
            }
            return output.ToString();
        }
        public Matrix(double[,] mat)
        {
            Mat = mat;
        }
    }
}
