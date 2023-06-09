using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class UniquePathsIII
    {
        (int, int) start;
        (int, int) end;
        int validCells = 0;
        int m = -1;
        int n = -1;
        int result = 0;
        //HashSet<string> paths;

        public int UniquePaths(int[][] grid)
        {
            m = grid.Length;
            n = grid[0].Length;
            validCells = 0;
            //paths=new();
            result = 0;

            int i = 0;
            int j = 0;
            while (i < m)
            {
                j = 0;
                while (j < n)
                {
                    if (grid[i][j] == 0)
                        validCells++;
                    if (grid[i][j] == 1)
                        start = (i, j);
                    if (grid[i][j] == 2)
                        end = (i, j);
                    j++;
                }
                i++;
            }

            //Console.WriteLine(validCells);

            Visit(0, start.Item1, start.Item2, new HashSet<(int, int)>(), grid);

            //paths.ToList().ForEach(x => Console.WriteLine(x));

            //return paths.Count;
            return result;
        }

        private void Visit(int current, int i, int j, HashSet<(int, int)> visited, int[][] grid)
        {
            if (i < 0 || j < 0 || i > m - 1 || j > n - 1)
                return;

            if (grid[i][j] == -1)
                return;

            if (visited.Contains((i, j)))
                return;

            visited.Add((i, j));

            if (i == end.Item1 && j == end.Item2)
            {
                if (current == validCells + 1)
                {
                    //StringBuilder sb = new();
                    //visited.ToList().ForEach(x => sb.Append(" " + x.Item1 + "," + x.Item2 + " "));               
                    //paths.Add(sb.ToString());
                    result++;
                }
                return;
            }

            Visit(current + 1, i + 1, j, new HashSet<(int, int)>(visited), grid);
            Visit(current + 1, i - 1, j, new HashSet<(int, int)>(visited), grid);
            Visit(current + 1, i, j + 1, new HashSet<(int, int)>(visited), grid);
            Visit(current + 1, i, j - 1, new HashSet<(int, int)>(visited), grid);
        }
    }
}
