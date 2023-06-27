using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    internal class Permutations
    {
        public static void CalculatePermutations(params int[] arr)
        {
            int n = arr.Length;
            bool[] used = new bool[n];
            int[] permutation = new int[n];

            CalculatePermutationsHelper(arr, permutation, used, 0);
        }

        private static void CalculatePermutationsHelper(int[] arr, int[] permutation, bool[] used, int level)
        {
            if (level == arr.Length)
            {
                PrintPermutation(permutation);
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutation[level] = arr[i];
                    CalculatePermutationsHelper(arr, permutation, used, level + 1);
                    used[i] = false;
                }
            }
        }

        private static void PrintPermutation(int[] permutation)
        {
            foreach (int num in permutation)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public static List<List<int>> GetPermutations(int[] nums)
        {
            List<List<int>> permutations = new List<List<int>>();
            Backtrack(0, nums, permutations);
            return permutations;
        }

        private static void Backtrack(int start, int[] nums, List<List<int>> permutations)
        {
            if (start == nums.Length - 1)
            {
                permutations.Add(nums.ToList());
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                Swap(nums, start, i);
                Backtrack(start + 1, nums, permutations);
                Swap(nums, start, i);
            }
        }

        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static List<List<int>> GetSubsets(int[] nums)
        {
            List<List<int>> subsets = new List<List<int>>();
            Backtrack(0, nums, new List<int>(), subsets);
            return subsets;
        }

        private static void Backtrack(int start, int[] nums, List<int> curr, List<List<int>> subsets)
        {
            subsets.Add(new List<int>(curr));
            for (int i = start; i < nums.Length; i++)
            {
                curr.Add(nums[i]);
                Backtrack(i + 1, nums, curr, subsets);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}
