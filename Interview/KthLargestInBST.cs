using System;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

class KthLargestInBST
{
    private Node root;
    private int count;

    public KthLargestInBST()
    {
        root = null;
        count = 0;
    }

    public void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.data)
            root.left = InsertRec(root.left, data);
        else if (data > root.data)
            root.right = InsertRec(root.right, data);

        return root;
    }

    public int FindNthLargest(int n)
    {
        count = 0;
        return FindNthLargestUtil(root, n);
    }

    private int FindNthLargestUtil(Node root, int n)
    {
        if (root == null)
            return -1;

        int right = FindNthLargestUtil(root.right, n);

        if (count != n)
        {
            count++;
            if (count == n)
                return root.data;

            return FindNthLargestUtil(root.left, n);
        }

        return right;
    }

    public static void Test()
    {
        KthLargestInBST tree = new KthLargestInBST();
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(20);
        tree.Insert(40);
        tree.Insert(70);
        tree.Insert(60);
        tree.Insert(80);

        //        50
        //    30          70
        //20      40 60       80

        int n = 7;
        int nthLargest = tree.FindNthLargest(n);

        if (nthLargest != -1)
            Console.WriteLine($"The {n}th largest element is: {nthLargest}");
        else
            Console.WriteLine($"There is no {n}th largest element in the BST.");

        Console.ReadLine();
    }
}
