using System;

namespace LeetCode0023Merge_k_SortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[1,4,5],[1,3,4],[2,6]]
            var x = MergeKLists(new ListNode[]
            {
                new ListNode(1)           
            });
            Console.WriteLine();
        }

        public static ListNode MergeKLists(ListNode[] lists) 
        {
            ListNode result = null;
            ListNode current = null;
            while(true)
            {
                var next = GetNext(lists);
                if (next == null)
                {
                    return result;
                }

                if (result == null)
                {
                    result = next;
                    current = next;
                    continue;
                }

                current.next = next;
                current = next;
            }
        }

        public static ListNode GetNext(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return null;
            }

            int? minIndex = null;
            for(var i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                if (minIndex == null)
                {
                    minIndex = i;
                    continue;
                }

                if (lists[i].val < lists[minIndex.Value].val)
                {
                    minIndex = i;
                }
            }

            if (minIndex == null)
            {
                return null;
            }

            ListNode result = lists[minIndex.Value];
            lists[minIndex.Value] = lists[minIndex.Value].next;
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
