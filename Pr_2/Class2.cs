namespace Lib8
{
    public class Class2
    {
        public static int[] FindMaxInColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] maxValues = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int max = matrix[0, j];
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxValues[j] = max;
            }
            return maxValues;
        }
    }
}
