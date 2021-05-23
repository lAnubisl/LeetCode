using System;

namespace LeetCode0021Merge2SortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2) 
        {
            ListNode result = GetNext(ref l1, ref l2);
            ListNode current = result;
            while(l1 != null || l2 != null)
            {
                current.next = GetNext(ref l1, ref l2);
                current = current.next;
            }

            return result;
        }

        private static ListNode GetNext(ref ListNode l1, ref ListNode l2)
        {
            ListNode result = null;
            if (l1 == null)
            {
                if (l2 == null)
                {
                    return null;
                }

                result = l2;
                l2 = l2.next;
                return result;
            }

            if (l2 == null || l1.val < l2.val)
            {
                result = l1;
                l1 = l1.next;
                return result;
            }

            result = l2;
            l2 = l2.next;
            return result;
        }
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