using System;
using System.IO;

namespace Libmas
{
    public class Class3
    {
        public static void FillMatrix(out int[,] matrix, int rows, int cols, int maxValue)
        {
            Random random = new Random();
            matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(-100, maxValue + 1);
                }
            }
        }
        public static void ClearMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public static void SaveMatrix(int[,] matrix, string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(matrix.GetLength(0));
                writer.WriteLine(matrix.GetLength(1));

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        writer.Write(matrix[i, j] + " ");
                    }
                    writer.WriteLine();
                }
            }
        }
        public static int[,] LoadMatrix(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                int rows = Convert.ToInt32(reader.ReadLine());
                int cols = Convert.ToInt32(reader.ReadLine());
                int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    string[] line = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(line[j]);
                    }
                }
                return matrix;
            }
        }
    }
}