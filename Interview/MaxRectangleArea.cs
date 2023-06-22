using System;

namespace Interview
{
    internal class MaxRectangleArea
    {
        static int GetArea(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] heights = new int[cols];
            int maxArea = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Update the heights array
                    if (matrix[row, col] == 0)
                        heights[col] = 0;
                    else
                        heights[col] += 1;

                    // Calculate the area of the largest rectangle using the heights array
                    int minHeight = heights[col];
                    for (int k = col; k > -1; k--)
                    {
                        if (heights[k] == 0)
                            break;
                        minHeight = Math.Min(minHeight, heights[k]);
                        int area = minHeight * (col - k + 1);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }

            return maxArea;
        }

        public static void Test()
        {
            int[,] matrix = {
                { 1, 0, 1, 1, 1 },
                { 0, 1, 1, 1, 1 },
                { 0, 1, 0, 1, 0 },
                { 1, 1, 1, 0, 1 }
            };

            int largestRectangleArea = GetArea(matrix);
            Console.WriteLine("Largest rectangle area: " + largestRectangleArea);
        }
    }
}
