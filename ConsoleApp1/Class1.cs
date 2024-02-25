
using System;
using System.Linq;

namespace ConsoleApp1
{
    public static class Class1
    {
        public static void Task1()
        {
            double[] A = new double[5];
            Console.WriteLine("Enter 5 numbers for array A:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = Convert.ToDouble(Console.ReadLine());
            }

            double[,] B = new double[3, 4];
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = rnd.NextDouble() * 100;
                }
            }

            Console.WriteLine("\nArray A:");
            foreach (var num in A)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\nArray B:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }

            double maxA = A[0], minA = A[0], sumA = 0, productA = 1, evenSumA = 0;
            foreach (var num in A)
            {
                if (num > maxA)
                    maxA = num;
                if (num < minA)
                    minA = num;
                sumA += num;
                productA *= num;
                if (num % 2 == 0)
                    evenSumA += num;
            }

            double oddColumnSumB = 0;
            for (int j = 0; j < 4; j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        oddColumnSumB += B[i, j];
                    }
                }
            }

            Console.WriteLine("\nMaximum element of array A: " + maxA);
            Console.WriteLine("Minimum element of array A: " + minA);
            Console.WriteLine("Total sum of elements of array A: " + sumA);
            Console.WriteLine("Total product of elements of array A: " + productA);
            Console.WriteLine("Sum of even elements of array A: " + evenSumA);
            Console.WriteLine("Sum of odd columns of array B: " + oddColumnSumB);
        }

        public static void Task2()
        {
            int[,] array = new int[5, 5];
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = rnd.Next(-100, 101);
                }
            }

            int min = array[0, 0];
            int max = array[0, 0];
            int minRowIndex = 0, minColIndex = 0;
            int maxRowIndex = 0, maxColIndex = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minRowIndex = i;
                        minColIndex = j;
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxRowIndex = i;
                        maxColIndex = j;
                    }
                }
            }

            int sum = 0;
            int startRow = Math.Min(minRowIndex, maxRowIndex) + 1;
            int endRow = Math.Max(minRowIndex, maxRowIndex);
            int startCol = Math.Min(minColIndex, maxColIndex) + 1;
            int endCol = Math.Max(minColIndex, maxColIndex);

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = startCol; j < endCol; j++)
                {
                    sum += array[i, j];
                }
            }

            Console.WriteLine($"Minimum element: {min}, located at position ({minRowIndex}, {minColIndex})");
            Console.WriteLine($"Maximum element: {max}, located at position ({maxRowIndex}, {maxColIndex})");
            Console.WriteLine($"Sum of elements between minimum and maximum: {sum}");
        }

        public static void Task3()
        {
            Console.WriteLine("Enter a string to encrypt:");
            string input = Console.ReadLine();

            int shift = 3; 
            string encryptedText = "";
            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    char shiftedChar = (char)(ch + shift);
                    if (char.IsUpper(ch) && shiftedChar > 'Z')
                        shiftedChar = (char)(shiftedChar - 26); 
                    else if (char.IsLower(ch) && shiftedChar > 'z')
                        shiftedChar = (char)(shiftedChar - 26); 

                    encryptedText += shiftedChar;
                }
                else
                {
                    encryptedText += ch; 
                }
            }

            Console.WriteLine("Encrypted text: " + encryptedText);

            string decryptedText = "";
            foreach (char ch in encryptedText)
            {
                if (char.IsLetter(ch))
                {
                    char shiftedChar = (char)(ch - shift);
                    if (char.IsUpper(ch) && shiftedChar < 'A')
                        shiftedChar = (char)(shiftedChar + 26); 
                    else if (char.IsLower(ch) && shiftedChar < 'a')
                        shiftedChar = (char)(shiftedChar + 26);

                    decryptedText += shiftedChar;
                }
                else
                {
                    decryptedText += ch; 
                }
            }

            Console.WriteLine("Decrypted text: " + decryptedText);
        }

        public static void Task4() 
        {
            Console.WriteLine("Enter the number of rows for the first matrix:");
            int rows1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns for the first matrix:");
            int cols1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter elements for the first matrix:");
            int[,] matrix1 = ReadMatrix(rows1, cols1);

            Console.WriteLine("Enter the number of rows for the second matrix:");
            int rows2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of columns for the second matrix:");
            int cols2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter elements for the second matrix:");
            int[,] matrix2 = ReadMatrix(rows2, cols2);

            Console.WriteLine("First Matrix:");
            PrintMatrix(matrix1);

            Console.WriteLine("Second Matrix:");
            PrintMatrix(matrix2);

            if (cols1 != rows2)
            {
                Console.WriteLine("Matrix multiplication is not possible. Number of columns of the first matrix must be equal to the number of rows of the second matrix.");
                return;
            }

            int scalar = 2;
            int[,] scaledMatrix = MultiplyMatrixByScalar(matrix1, scalar);
            Console.WriteLine($"Result of multiplying the first matrix by {scalar}:");
            PrintMatrix(scaledMatrix);

            int[,] sumMatrix = AddMatrices(matrix1, matrix2);
            Console.WriteLine("Result of adding the two matrices:");
            PrintMatrix(sumMatrix);

            int[,] productMatrix = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("Result of multiplying the two matrices:");
            PrintMatrix(productMatrix);
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] rowValues = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(rowValues[j]);
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
    }

   }

