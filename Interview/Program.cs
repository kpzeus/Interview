using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("Started");
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
            //DecibinaryNumbers.GetMatch(2, 0, 0, 2, z);
            //z.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(1) == 0);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(2) == 1);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(3) == 2);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(4) == 10);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(10) == 100);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(30) == 32);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(29) == 24);
            Console.WriteLine(DecibinaryNumbers.decibinaryNumbers(44) == 121);

            //Console.WriteLine(DecibinaryNumbers.Eval(4, 4));
            //Console.WriteLine(DecibinaryNumbers.Eval(12, 4));
            //Console.WriteLine(DecibinaryNumbers.Eval(20, 4));
            //Console.WriteLine(DecibinaryNumbers.Eval(100,4));
            //Console.WriteLine(DecibinaryNumbers.Eval(101, 4));
            //Console.WriteLine(DecibinaryNumbers.Eval(202, 10));

            Console.WriteLine("Duration : " + (DateTime.Now - start).TotalMilliseconds);

            Console.Read();
        }
    }
}
