using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class TSPSolver
    {
        private int[,] distances; // Matrix of distances between cities
        private int numCities; // Number of cities
        private int[] bestTour; // Best tour found so far
        private int bestTourLength; // Length of the best tour

        public TSPSolver(int[,] distances)
        {
            this.distances = distances;
            numCities = distances.GetLength(0);
            bestTour = new int[numCities];
            bestTourLength = int.MaxValue;
        }

        public void Solve()
        {
            int[] currentTour = new int[numCities];
            bool[] visited = new bool[numCities];

            currentTour[0] = 0; // Start at the first city
            visited[0] = true;
            Permute(1, currentTour, visited); // Generate all permutations

            Console.WriteLine("Best tour: " + string.Join(" -> ", bestTour));
            Console.WriteLine("Tour length: " + bestTourLength);
        }

        private void Permute(int level, int[] currentTour, bool[] visited)
        {
            if (level == numCities)
            {
                int tourLength = CalculateTourLength(currentTour);
                if (tourLength < bestTourLength)
                {
                    Array.Copy(currentTour, bestTour, numCities);
                    bestTourLength = tourLength;
                }
                return;
            }

            for (int i = 0; i < numCities; i++)
            {
                if (!visited[i])
                {
                    currentTour[level] = i;
                    visited[i] = true;
                    Permute(level + 1, currentTour, visited);
                    visited[i] = false;
                }
            }
        }

        private int CalculateTourLength(int[] tour)
        {
            int tourLength = 0;
            for (int i = 0; i < numCities - 1; i++)
            {
                int city1 = tour[i];
                int city2 = tour[i + 1];
                tourLength += distances[city1, city2];
            }
            // Return to the starting city
            tourLength += distances[tour[numCities - 1], tour[0]];
            return tourLength;
        }

        public static void Test()
        {
            int[,] distances = new int[,]
            {
            { 0, 10, 15, 20 },
            { 10, 0, 35, 25 },
            { 15, 35, 0, 30 },
            { 20, 25, 30, 0 }
            };

            TSPSolver solver = new TSPSolver(distances);
            solver.Solve();
        }
    }
}
