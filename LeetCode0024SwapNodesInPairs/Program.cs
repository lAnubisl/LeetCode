using System;

namespace LeetCode0024SwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SwapPairs(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
            Console.WriteLine("Hello World!");
        }

        public static ListNode SwapPairs(ListNode head) 
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            ListNode previous = null;
            ListNode current = head;
            head = head.next;

            while(Swap(previous, current, current?.next))
            {
                previous = current;
                current = current.next;        
            }

            return head;
        }

        private static bool Swap(ListNode previous, ListNode current, ListNode next)
        {
            if (next == null)
            {
                return false;
            }

            current.next = next.next;
            next.next = current;
            if (previous != null)
            {
                previous.next = next;
            }
            
            return true;
        }
    }

    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) 
        {
            this.val = val;
            this.next = next;
        }
    }
}
