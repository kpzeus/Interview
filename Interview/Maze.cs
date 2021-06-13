using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class Maze
    {
        public static int minimumMoves(List<string> grid, int startX, int startY, int goalX, int goalY)
        {
            Queue<Tuple<int, int, int>> q = new Queue<Tuple<int, int, int>>();
            q.Enqueue(new Tuple<int, int, int>(startX, startY, 0));

            while (q.Count > 0)
            {
                var item = q.Dequeue();

                var x = item.Item1;
                var y = item.Item2;

                Console.WriteLine(x + "," + y + " = " + item.Item3);

                if (x == goalX && y == goalY)
                    return item.Item3;

                var targetMove = GetRightMove(grid, x, y);                
                if (targetMove.Item1 != x || targetMove.Item2 != y)
                {
                    Console.WriteLine("New Right Loc : " + targetMove.Item1 + "," + targetMove.Item2);
                    q.Enqueue(new Tuple<int, int, int>(
                        targetMove.Item1,
                        targetMove.Item2,
                        item.Item3 + 1));
                }

                targetMove = GetLeftMove(grid, x, y);
                if (targetMove.Item1 != x || targetMove.Item2 != y)
                {
                    Console.WriteLine("New Left Loc : " + targetMove.Item1 + "," + targetMove.Item2);
                    q.Enqueue(new Tuple<int, int, int>(
                        targetMove.Item1,
                        targetMove.Item2,
                        item.Item3 + 1));
                }

                targetMove = GetTopMove(grid, x, y);
                if (targetMove.Item1 != x || targetMove.Item2 != y)
                {
                    Console.WriteLine("New Top Loc : " + targetMove.Item1 + "," + targetMove.Item2);
                    q.Enqueue(new Tuple<int, int, int>(
                        targetMove.Item1,
                        targetMove.Item2,
                        item.Item3 + 1));
                }

                targetMove = GetBottomMove(grid, x, y);
                if (targetMove.Item1 != x || targetMove.Item2 != y)
                {
                    Console.WriteLine("New Bottom Loc : " + targetMove.Item1 + "," + targetMove.Item2);
                    q.Enqueue(new Tuple<int, int, int>(
                        targetMove.Item1,
                        targetMove.Item2,
                        item.Item3 + 1));
                }
            }

            return -1;
        }

        static Tuple<int, int> GetRightMove(List<string> grid, int x, int y)
        {
            int r = x;
            int c = y + 1;
            int s = 0;

            while (c < grid[0].Length && grid[r][c] != 'X')
            {
                s++;
                var row = grid[r].ToCharArray();
                row[c] = 'X';
                grid[r] = new string(row);
                c++;
            }

            return new Tuple<int, int>(x, y + s);
        }

        static Tuple<int, int> GetLeftMove(List<string> grid, int x, int y)
        {
            int r = x;
            int c = y - 1;
            int s = 0;

            while (c > -1 && grid[r][c] != 'X')
            {
                s++;
                var row = grid[r].ToCharArray();
                row[c] = 'X';
                grid[r] = new string(row);
                c--;
            }

            return new Tuple<int, int>(x, y - s);
        }

        static Tuple<int, int> GetTopMove(List<string> grid, int x, int y)
        {
            int r = x - 1;
            int c = y;
            int s = 0;

            while (r > -1 && grid[r][c] != 'X')
            {
                s++;
                var row = grid[r].ToCharArray();
                row[c] = 'X';
                grid[r] = new string(row);
                r--;
            }

            return new Tuple<int, int>(x - s, y);
        }

        static Tuple<int, int> GetBottomMove(List<string> grid, int x, int y)
        {
            int r = x + 1;
            int c = y;
            int s = 0;

            while (r < grid.Count && grid[r][c] != 'X')
            {
                s++;
                var row = grid[r].ToCharArray();
                row[c] = 'X';
                grid[r] = new string(row);
                r++;
            }

            return new Tuple<int, int>(x + s, y);
        }
    }
}
