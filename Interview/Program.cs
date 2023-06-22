using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Interview.ArrayQns;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Started");

            try
            {
                //SubMatrixSumToTarget.Test();
                KthLargestInBST.Test();
                //var x = new MatrixQns().UniquePaths(3, 7);
                //Console.WriteLine(x);
                //Permutations.CalculatePermutations(235745376, 19645448, 157163584, 471490752, 117872688, 589363440, 294681720, 147340860, 442022580, 73670430, 12278405, 110505645, 773539515, 257846505);
                //var x = new TreeQns().RecoverFromPreorder("1-2--3--4-5--6--7");
                //Console.WriteLine(x);
                //Console.WriteLine(ArrayQns.Gcd(10,8));
                //Console.WriteLine(ArrayQns.Gcd(8, 10));
                //int[][] edges = new int[2][];
                //edges[0] = new int[2];
                //edges[0][0] = 3;
                //edges[0][1] = 4;
                //edges[1] = new int[2];
                //edges[1][0] = 4;
                //edges[1][1] = 5;
                //var x = new ArrayQns().CountCompleteComponents(6, edges);
                //Console.WriteLine(x);
                //var x = new ArrayQns().DoesValidArrayExist(new int[] { 1, 1, 0 });
                //Console.WriteLine(x);
                //x = new ArrayQns().DoesValidArrayExist(new int[] { 1, 1 });
                //Console.WriteLine(x);
                //x = new ArrayQns().DoesValidArrayExist(new int[] { 1, 0 });
                //Console.WriteLine(x);
                //var x = new ArrayQns().SumOfPower(new int[] { 2, 1, 4 });
                //Console.WriteLine(x);
                //var x = Permutations.GetSubsets(new int[] { 2, 1, 4 });
                //x.ForEach(y =>
                //{
                //    y.ForEach(z => { Console.Write(z + " "); });
                //    Console.WriteLine();
                //});
                //var x = new ArrayQns().LongestObstacleCourseAtEachPosition(new int[] { 1, 2, 3, 2 });
                //Assert.AreEqual(3, x[3]);
                //x = new ArrayQns().LongestObstacleCourseAtEachPosition(new int[] { 2, 2, 1 });
                //Assert.AreEqual(1, x[2]);
                //x = new ArrayQns().LongestObstacleCourseAtEachPosition(new int[] { 5, 1, 5, 5, 1, 3, 4, 5, 1, 4 });
                //Assert.AreEqual(5, x[9]);
                //var x = new ArrayQns().RoadFuel(new int[] { 0, 1, 1 }, new int[] { 1, 2, 3 });
                //Assert.AreEqual(3, x);
                //x = new ArrayQns().RoadFuel(new int[] { 1, 1, 1, 9, 9, 9, 9, 7, 8}, new int[] { 2, 0, 3, 1, 6, 5, 4, 0, 0 });
                //Assert.AreEqual(10, x);
                //int[] arr = new int[] { 1, 2, 1 };
                //int[] brr = new int[] { 2, 1, 1 };
                //int x = 0;
                //x = ArrayQns.InviteFriends(3, arr, brr);
                //Assert.AreEqual(2, x);

                //arr = new int[] { 0, 0 };
                //brr = new int[] { 0, 1 };
                //x = ArrayQns.InviteFriends(2, arr, brr);
                //Assert.AreEqual(1, x);

                //arr = new int[] { 8, 3, 6, 6, 6, 3, 5, 2, 3 };
                //brr = new int[] { 6, 5, 8, 3, 3, 2, 1, 3, 8 };
                //x = ArrayQns.InviteFriends(9, arr, brr);
                //Assert.AreEqual(5, x);

                //arr = new int[] { 6, 7, 8, 9, 7, 9, 2, 0, 4, 0 };
                //brr = new int[] { 8, 0, 5, 7, 5, 2, 8, 9, 7, 9 };
                //x = ArrayQns.InviteFriends(10, arr, brr);
                //Assert.AreEqual(7, x);

                //arr = new int[] { 6, 3, 5, 0, 1, 0, 6, 0, 4, 4 };
                //brr = new int[] { 7, 7, 4, 9, 4, 6, 3, 3, 3, 9 };
                //x = ArrayQns.InviteFriends(10, arr, brr);
                //Assert.AreEqual(5, x);

                //arr = new int[] { 0, 0, 4, 1, 5, 8, 6, 1, 7, 4 };
                //brr = new int[] { 4, 1, 0, 2, 1, 8, 5, 1, 2, 1 };
                //x = ArrayQns.InviteFriends(10, arr, brr);
                //Assert.AreEqual(4, x);

                //var x = new ArrayQns().SmallestBeautifulString("abcz", 26);

                //var q = new HashSet<int> { 1, 2 };
                //var e = new HashSet<int> { 1, 2 };
                //var hashCode = q.Aggregate(0, (a, v) =>
                //    HashCode.Combine(a, v.GetHashCode()));
                //var hashCode1 = e.Aggregate(0, (a, v) =>
                //    HashCode.Combine(a, v.GetHashCode()));

                //var p = new ArrayQns().GetAllPermutations(0,1,2);

                //int x = 0;
                //x = new ArrayQns().ProfitableSchemes(5, 3, new int[] { 2, 2 }, new int[] { 2, 3 });
                //Assert.AreEqual(2, x);
                //Console.WriteLine();
                //x = new ArrayQns().ProfitableSchemes(10, 5, new int[] { 2, 3, 5 }, new int[] { 6, 7, 8 });
                //Assert.AreEqual(7, x);
                //Console.WriteLine();
                //x = new ArrayQns().ProfitableSchemes(1, 1, new int[] { 2, 2, 2, 2, 2 }, new int[] { 1, 2, 1, 1, 0 });
                //Assert.AreEqual(0, x);
                //Console.WriteLine();
                //x = new ArrayQns().ProfitableSchemes(64, 0, new int[] { 80, 40 }, new int[] { 88, 88 });
                //Assert.AreEqual(2, x);
                //Console.WriteLine();

                //int[] x;
                //x = new ArrayQns().MinReverseOperations(4, 0, new int[] { 1, 2 }, 4);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(1, x[3]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(5, 0, new int[] { 2, 4 }, 3);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(-1, x[1]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(2, 1, new int[] { }, 2);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(1, x[0]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(
                //    3, 0, new int[] { }, 3);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(-1, x[1]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(
                //  3, 1, new int[] { }, 3);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(-1, x[0]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(
                //4, 2, new int[] { }, 4);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(1, x[1]);
                //Console.WriteLine();
                //x = new ArrayQns().MinReverseOperations(
                //5, 0, new int[] { }, 2);
                //x.ToList().ForEach(x => Console.Write(x + " "));
                //Assert.AreEqual(4, x[4]);
                //Console.WriteLine();

                //var x = ArrayQns.ParseNestedList("[[1,100,3],[7,8,9]]");
                //int y;
                //y = new ArrayQns().MaxValueOfCoins(x, 2);
                //Assert.AreEqual(101, y);
                //x = ArrayQns.ParseNestedList("[[100],[100],[100],[100],[100],[100],[1,1,1,1,1,1,700]]");
                //y = new ArrayQns().MaxValueOfCoins(x, 7);
                //Assert.AreEqual(706, y);
                //x = ArrayQns.ParseNestedList("[[48,14,23,38,33,79,3,52,73,58,49,23,74,44,69,76,83,41,46,32,28]]");
                //y = new ArrayQns().MaxValueOfCoins(x, 10);
                //Assert.AreEqual(421, y);
                //x = ArrayQns.ParseNestedList("[[37,88],[51,64,65,20,95,30,26],[9,62,20],[44]]");
                //y = new ArrayQns().MaxValueOfCoins(x, 9);
                //Assert.AreEqual(494, y);

                //int[][] m = new int[4][];
                //m[0] = new int[4];
                //m[1] = new int[4];
                //m[2] = new int[4];
                //m[3] = new int[4];

                //Pos s = new Pos();
                //s.X = 0;
                //s.Y = 0;

                //Pos e = new Pos();
                //e.X = 3;
                //e.Y = 3;

                //Console.WriteLine(new Search(m).GetMinPath(s, e));

                //Console.WriteLine(Eval.Parse("50 + 4 * ( 8 + 2 )"));
                //Console.WriteLine(Eval.Parse("10 + 2 * 6"));
                //Console.WriteLine(Eval.Parse("100 * 2 + 12"));
                //Console.WriteLine(Eval.Parse("100 * ( 2 + 12 )"));
                //Console.WriteLine(Eval.Parse("100 * ( 2 + 12 ) / 14"));

                //RotatedArraySearch s = new RotatedArraySearch(5, 6, 7, 8, 9, 10, 1, 2, 3, 4);
                //Console.WriteLine(RotatedArraySearch.GetIndex(s.values, 10));
                //Console.WriteLine(RotatedArraySearch.GetIndex(s.values, 3));
                //s = new RotatedArraySearch(1,2,3,4);
                //Console.WriteLine(RotatedArraySearch.GetIndex(s.values, 3));
                //s = new RotatedArraySearch(1, 2, 3, 4);
                //Console.WriteLine(RotatedArraySearch.GetIndex(s.values, 5));

                //LL x = new LL(5, new LL(6, new LL(3, null)));
                //LL y = new LL(8, new LL(4, new LL(2, null)));
                //LinkListAdd.Print(LinkListAdd.Add(x, y));
                //Console.WriteLine();
                //LinkListAdd.Print(LinkListAdd.Reverse(x));

                //Node root = new Node(1);
                //root.left = new Node(2);
                //root.right = new Node(3);
                //root.left.left = new Node(4);
                //root.left.right = new Node(5);
                //root.right.left = new Node(6);

                //root = TreeQns.Connect(root);
                //Console.WriteLine();

                //Console.WriteLine(StringQns.RemoveDuplicates("prasanna".ToCharArray()));

                //Console.WriteLine(StringQns.ValidIPAddress("1.0.1."));

                //Console.WriteLine(ArrayQns.GetMaxSumContiguousSubarray(-2, 1, -3, 4, -1, 2, 1, -5, 4));

                //ArrayQns.GenSpiralMatrix(4);

                //Console.WriteLine(ArrayQns.GetLargestNumberFormed(3,30,34,9));

                //Console.WriteLine(ArrayQns.PlusOne(1,2,3));

                //int[,] A = { { 1, 2, 3, 4 },
                //      { 5, 6, 7, 8 },
                //      { 9, 10, 11, 12 },
                //      { 13, 14, 15, 16 } };

                //ArrayQns.AntiDiagonals(A);

                //Console.WriteLine(ArrayQns.HotelBookings(new int[]{ 1,3,5 }, new int[] { 2,6,8}, 1));

                //Console.WriteLine(ArrayQns.SearchRange(new int[] { 1,4 }, 4));

                //Console.WriteLine(ArrayQns.MySqrt(2147395599));

                //Console.WriteLine(ArrayQns.RomanToInt("IV"));

                //Console.WriteLine(StringQns.AddBinary("11", "1"));

                //Console.WriteLine(StringQns.ReverseWords("the sky is blue"));

                //ArrayQns.SortColors(new int[] { 2, 0, 2, 1, 1, 0 });

                //LRUCache x = new LRUCache(2);
                //x.Put(1, 1);
                //x.Put(2, 2);
                //Console.WriteLine(x.Get(1));
                //x.Put(3, 3);
                //Console.WriteLine(x.Get(2));
                //x.Put(4, 4);
                //Console.WriteLine(x.Get(1));
                //Console.WriteLine(x.Get(3));
                //Console.WriteLine(x.Get(4));

                //Console.WriteLine(x.Get(2));
                //x.Put(2, 6);
                //Console.WriteLine(x.Get(1));
                //x.Put(1, 5);
                //x.Put(1, 2);
                //Console.WriteLine(x.Get(1));
                //Console.WriteLine(x.Get(2));

                //HashSet<String> D = new HashSet<String>();
                //D.Add("hot");
                //D.Add("dot");
                //D.Add("dog");
                //D.Add("lot");
                //D.Add("log");
                //D.Add("cog");
                //String start = "hit";
                //String target = "cog";
                ////Console.Write("Length of shortest chain is: "
                ////    + WordLadder.LadderLength(start, target, D.ToList()));

                ////WordLadder.FindLadders(start, target, D.ToList());

                //Console.WriteLine(new string("123".Reverse().ToArray()));

                //ListNode x = new ListNode(4, new ListNode(8, new ListNode(15, new ListNode(19, null))));
                //ListNode y = new ListNode(7, new ListNode(9, new ListNode(10, new ListNode(16, null))));
                //LinkListQns.Print(LinkListQns.Merge(x, y));
                //Console.WriteLine();

                //ListNode x = new ListNode(4, new ListNode(8, new ListNode(15, new ListNode(19, null))));
                //x.arb = x.next.next.next;
                //x.next.arb = x;
                //var z = LinkListQns.DeepCopy(x);
                //LinkListQns.Print(z);
                //Console.WriteLine();

                //Node root = new Node(100);
                //root.left = new Node(50);
                //root.right = new Node(200);
                //root.left.left = new Node(25);
                //root.left.right = new Node(75);
                //root.right.right = new Node(350);

                //TreeQns.LevelOrder(root);
                //Console.WriteLine();

                //Console.WriteLine(StringQns.ReverseWordsInLine("Hello World"));
                //Console.WriteLine(StringQns.ReverseWordsInLine("Hello World "));
                //Console.WriteLine(StringQns.ReverseWordsInLine("Hello   World"));

                //HashSet<string> ways = new HashSet<string>();
                //ArrayQns.WaysOfDenominations(7, new int[] { 1, 2, 5 }, ways);
                //ways.ToList().ForEach(x => Console.WriteLine(x));

                //Autocomplete t = new Autocomplete();
                //t.InsertWord("tea");
                //t.InsertWord("thing");
                //t.GetWordsForPrefix("t").ForEach(x =>
                //{
                //    Console.WriteLine(x);
                //});
                //t.GetWordsForPrefix("te").ForEach(x =>
                //{
                //    Console.WriteLine(x);
                //});

                //Console.WriteLine(ArrayQns.candies(100000, Enumerable.Range(1, 100000).Reverse().ToList()));

                //List<string> x = new List<string>();
                //x.Add("...");
                //x.Add(".X.");
                //x.Add(".X.");

                //Console.WriteLine(Maze.minimumMoves(x, 2, 0, 2, 2));

                //var x = new List<string>();
                //x.Add(".X..XX...X");
                //x.Add("X.........");
                //x.Add(".X.......X");

                //x.Add("..........");
                //x.Add("........X.");
                //x.Add(".X...XXX..");

                //x.Add(".....X..XX");
                //x.Add(".....X.X..");
                //x.Add("..........");

                //x.Add(".....X..XX");

                //Console.WriteLine(Maze.minimumMoves(x, 9, 1, 9, 6));

                //Console.WriteLine(Brackets.BracketCombinations(3));

                //Console.WriteLine(StringQns.MinWindowSubstring("aabdccdbcacd", "aad"));

                //Console.WriteLine(TreeQns.IsTreePossible(new string[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" }));

                //Console.WriteLine(TreeQns.IsTreePossible(new string[] { "(1,2)", "(3,2)", "(2,12)", "(5,2)" }));

                //BitQns.Allergies a = new BitQns.Allergies(131);

                //a.List().ToList().ForEach(x => Console.WriteLine(x.ToString()));

                //Console.WriteLine(StringQns.ROT13("The quick brown fox jumps over the lazy dog."));

                //Console.WriteLine(ArrayQns.canSum(new List<int>() { 7, 14 }, 30000));

                //ArrayQns.howSum(new List<int>() { 7, 14 }, 7)?.ForEach(
                //    x =>
                //    {
                //        Console.Write(x + " ");
                //    });
                //Console.WriteLine();
                //ArrayQns.howSum(new List<int>() { 7, 14 }, 14)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.howSum(new List<int>() { 7, 14 }, 21)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                // ArrayQns.howSum(new List<int>() { 7, 14 }, 15)?.ForEach(
                //    x =>
                //    {
                //        Console.Write(x + " ");
                //    });
                //Console.WriteLine();
                //Console.WriteLine();
                //ArrayQns.howSum(new List<int>() { 7, 14 }, 300)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.howSum(new List<int>() { 7, 14 }, 301)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();

                //ArrayQns.bestSum(new List<int>() { 7, 14 }, 7)?.ForEach(
                //    x =>
                //    {
                //        Console.Write(x + " ");
                //    });
                //Console.WriteLine();
                //ArrayQns.bestSum(new List<int>() { 7, 14 }, 14)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.bestSum(new List<int>() { 7, 14 }, 21)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.bestSum(new List<int>() { 7, 14 }, 15)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.bestSum(new List<int>() { 7, 14 }, 300)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();
                //ArrayQns.bestSum(new List<int>() { 1,2,5,25 }, 100)?.ForEach(
                //   x =>
                //   {
                //       Console.Write(x + " ");
                //   });
                //Console.WriteLine();

                //Console.WriteLine(ArrayQns.fib(6));

                //Console.WriteLine(ArrayQns.canSumTabular(7, 5, 3, 4));

                //Console.WriteLine(ArrayQns.canSumTabular(1, 5, 3, 4));

                //ArrayQns.howSumTabular(7, 5, 3, 4)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();

                //ArrayQns.howSumTabular(6, 5, 3, 4)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();

                //ArrayQns.howSumTabular(1, 5, 3, 4)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();

                //ArrayQns.bestSumTabular(7, 5, 3, 4)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();

                //ArrayQns.bestSumTabular(6, 5, 3, 4)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();

                //ArrayQns.bestSumTabular(100, 1, 2, 5, 25)?.ForEach(x => Console.Write(x + " "));
                //Console.WriteLine();


                //DecibinaryNumbers.GetMatch(1, 0, 2, z);            
                //DecibinaryNumbers.GetMatches(4).ForEach(x => Console.WriteLine(x));

                //var z = new List<long>();
                //DecibinaryNumbers.GetMatch(4, 0, 0, 3, z);
                //z.ForEach(x => Console.WriteLine(x));

                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(1) == 0);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(2) == 1);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(3) == 2);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(4) == 10);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(10) == 100);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(30) == 32);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(29) == 24);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(44) == 121);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(4592999) == 2394628);
                //Console.WriteLine(DecibinaryNumbers2.decibinaryNumbers(4284323577117864) == 5124105853195114);

                //Console.WriteLine(DecibinaryNumbers.Eval(4, 4));
                //Console.WriteLine(DecibinaryNumbers.Eval(12, 4));
                //Console.WriteLine(DecibinaryNumbers.Eval(20, 4));
                //Console.WriteLine(DecibinaryNumbers.Eval(100,4));
                //Console.WriteLine(DecibinaryNumbers.Eval(101, 4));
                //Console.WriteLine(DecibinaryNumbers.Eval(202, 10));

                //Console.WriteLine(BitQns.CountSmallestSubSetForMaxBitWiseOR(5, 1, 3, 4, 2));
                //Console.WriteLine(BitQns.CountSmallestSubSetForMaxBitWiseOR(2, 6, 2, 8, 4, 5));

                //Console.WriteLine(ArrayQns.MaximumSizeSubsetWithGivenSum(10, 2, 3, 5, 7, 10, 15));
                //Console.WriteLine(ArrayQns.MaximumSizeSubsetWithGivenSum(4, 1, 2, 3, 4, 5));

                //Console.WriteLine("Duration : " + (DateTime.Now - start).TotalMilliseconds);

                //TreeNode root = new TreeNode(2);
                //root.left = new TreeNode(2);
                //root.right = new TreeNode(2);

                //root = new TreeNode(int.MinValue);

                //Console.WriteLine(TreeQns.isBST(root));
                //Console.WriteLine();

                //Console.WriteLine(ArrayQns.StrStr("mississippi", "issip"));

                //Console.WriteLine(ArrayQns.LongestCommonPrefix("flower", "flow", "flight"));

                //int[][] matrix = new int[3][];
                //matrix[0] = new int[] { 1, 2, 3 };
                //matrix[1] = new int[] { 4, 5, 6 };
                //matrix[2] = new int[] { 7, 8, 9 };

                //MatrixQns.Rotate(matrix);

                //matrix.ToList().ForEach(x =>
                //{
                //    x.ToList().ForEach(y =>
                //    {
                //        Console.Write(y + " ");
                //    });
                //    Console.WriteLine();
                //});

                //Console.WriteLine(ArrayQns.IsValidBrackets("()"));

                //Console.WriteLine(ArrayQns.FindDisappearedNumbers(4, 3, 2, 7, 8, 2, 3, 1));

                //Console.WriteLine(ArrayQns.FindDisappearedNumbers(1, 1));

                //var x = TreeQns.BuildTree(new int[]{ 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });

                //Console.WriteLine("Done");

                //MyCircularQueue x = new MyCircularQueue(6);
                //x.EnQueue(6);
                //Console.WriteLine(x.Rear() == 6);
                //Console.WriteLine(x.Rear() == 6);
                //Console.WriteLine(x.DeQueue());
                //Console.WriteLine(x.EnQueue(5));
                //Console.WriteLine(x.Rear() == 5);
                //Console.WriteLine(x.DeQueue());
                //Console.WriteLine(x.Front() == 0);

                //Console.WriteLine(Recursion.NumSquares(12));

                //MyStack stack = new MyStack();
                //stack.Push(1);
                //stack.Push(2);
                //Console.WriteLine(stack.Top() == 2);
                //Console.WriteLine(stack.Pop() == 2);

                //var x = ArrayQns.SortArray(new int[] { 5, 2, 3, 1 });

                //var x = ArrayQns.GenerateParenthesis(3);

                //var x = ArrayQns.LetterCombinations("23");

                //ListNode l = new ListNode(1, 
                //    new ListNode(2, 
                //    new ListNode(3, 
                //    new ListNode(4,
                //    new ListNode(5, null)))));

                //Console.WriteLine(ArrayQns.PotHoles3("x..xx.", "..xxx."));

                //x..xx.
                //..xxx.

                //Console.WriteLine(ArrayQns.PotHoles2("x..xx.", "..xxx.", 0, true));
                //Console.WriteLine(ArrayQns.PotHoles2("x..xx.", "..xxx.", 0, false));

                //Console.WriteLine(ArrayQns.PotHoles2("x.x.x.", ".x.x.x"));
                //Console.WriteLine(ArrayQns.PotHoles2("x..xx.", "..xxx."));

                //ArrayQns x = new ArrayQns();
                //var y = x.Exist(new char[][] {
                //    new char[] { 'A', 'B', 'C', 'E' },
                //    new char[] { 'S', 'F', 'C', 'S' },
                //    new char[] { 'A', 'D', 'E', 'E' } },
                //    "ABCCED");

                //TempTracker t = new TempTracker();
                //t.Record(100);
                //Console.WriteLine(t.GetMax());
                //Thread.Sleep(1000);
                //t.Record(50);
                //t.Record(80);
                //Console.WriteLine(t.GetMax());
                //Thread.Sleep(2000);
                //Console.WriteLine(t.GetMax());
                //t.Record(120);
                //Console.WriteLine(t.GetMax());

                //ArrayQns x = new ArrayQns();
                //var y = x.RemoveDuplicates(new int[] {-3, -1, -1, 0, 0, 0, 0, 0, 2});
                //var y = x.FindDiagonalOrder(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4,5,6 }, new int[] { 7,8,9} });
                //var y = x.LongestCommonSubsequence("ezupkr","ubmrapg");
                //var y = x.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 });
                //var y = x.MaxLength(new string[] { "ab", "fg", "ae" });
                //var z = x.MaxLength(new string[] { "abcdefghijklmnopqrstuvwxyz" });
                //var z = x.MaxLength(new string[] { "a", "abc", "d", "de", "def" });
                //var z = x.MaxLength(new string[] { "ab", "cd", "cde", "cdef", "efg", "fgh", "abxyz" });
                //var z = x.GetFilters(new int[] { 100, 100, 0, 0, 50 });

                Console.WriteLine("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }
    }
}