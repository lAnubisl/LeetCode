using System;

namespace LeetCode0025ReverseNodesInK_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var result = ReverseKGroup(root, 3);
            while(result != null)
            {
                Console.Write(result.val + ", ");
                result = result.next;
            }
        }

        public static ListNode ReverseKGroup(ListNode head, int k) 
        {
            bool headOwerridden = false;
            var current = head;
            ListNode previous = null;
            while(true)
            {
                if (current == null)
                {
                    return head;
                }

                var boundary = GetBoundary(current, k);
                if (boundary == null)
                {
                    return head;
                }

                if (previous != null)
                {
                    previous.next = boundary.Left;
                }

                var next = current.next;
                current.next = boundary.Right;
                previous = current;
                while(next != null)
                {
                    var temp = next.next;
                    next.next = current;
                    current = next;
                    next = temp;
                }

                if (!headOwerridden)
                {
                    head = current;
                    headOwerridden = true;
                }

                current = boundary.Right;
            }
        }

        private static Boundary GetBoundary(ListNode current, int k)
        {
            while(k > 1)
            {
                if (current.next == null)
                {
                    return null;
                }

                current = current.next;
                k--;
            }

            var b = new Boundary{ Left = current, Right = current.next };
            current.next = null;
            return b;          
        }
    }

    public class Boundary
    {
        public ListNode Left, Right;
    }

    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
    }
}
