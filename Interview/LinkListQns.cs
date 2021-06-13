using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class ListNode
    {
        public ListNode(int data, ListNode next)
        {
            this.next = next;
            this.val = data;
        }

        public ListNode next;
        public ListNode arb;
        public int val;
    }

    public class LinkListQns
    {
        public static ListNode DeepCopy(ListNode x)
        {
            if (x == null)
                return x;

            ListNode ori = x;

            ListNode head = new ListNode(x.val, null);

            Dictionary<ListNode, ListNode> map = new Dictionary<ListNode, ListNode>();
            map.Add(x, head);

            x = x.next;
            var c = head;
            while(x != null)
            {               
                c.next = new ListNode(x.val, null);
                map.Add(x, c.next);
                x = x.next;
                c = c.next;
            }

            c = head;
            x = ori;

            while (c != null)
            {
                if(x.arb != null)
                {
                    c.arb = map[x.arb];
                }
                x = x.next;
                c = c.next;
            }
            
            return head;
        }

        public static ListNode Merge(ListNode x, ListNode y)
        {
            ListNode head = null;

            if (x == null)
                return y;

            if (y == null)
                return x;

            if(x.val <= y.val)
            {
                head = x;
                x = x.next;
            }
            else
            {
                head = y;
                y = y.next;
            }

            ListNode c = head;

            while(x != null && y != null)
            {
                if (x.val <= y.val)
                {
                    c.next = x;
                    x = x.next;
                }
                else
                {
                    c.next = y;
                    y = y.next;
                }
                c = c.next;
            }

            while (x != null)
            {
                c.next = x;
                x = x.next;
                c = c.next;
            }

            while (y != null)
            {
                c.next = y;
                y = y.next;
                c = c.next;
            }

            return head;
        }

        public static ListNode Add(ListNode x, ListNode y)
        {
            if (x == null)
                return y;

            if (y == null)
                return x;

            Stack<int> a = new Stack<int>();
            Stack<int> b = new Stack<int>();

            while (x != null)
            {
                a.Push(x.val);
                x = x.next;
            }

            while (y != null)
            {
                b.Push(y.val);
                y = y.next;
            }

            ListNode head = new ListNode(0, null);
            bool carry = false;

            while(a.Count > 0 || b.Count > 0)
            {
                if (a.Count > 0)
                    head.val = head.val + a.Pop();

                if (b.Count > 0)
                    head.val = head.val + b.Pop();

                if(head.val > 9)
                {
                    carry = true;
                    head.val = head.val - 10;
                }

                ListNode newHead = null;

                if (carry)
                {
                    newHead = new ListNode(1, head);
                }
                else
                {
                    newHead = new ListNode(0, head);
                }

                head = newHead;
            }


            return head;
        }

        public static void Print(ListNode x)
        {
            while(x != null)
            {
                Console.Write(x.val + " ");
                x = x.next;
            }
        }

        public static ListNode Reverse(ListNode head)
        {
            ListNode current = head;
            ListNode prev = null;
            ListNode next = null;

            while(current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;

            return head;
        }
    }
}
