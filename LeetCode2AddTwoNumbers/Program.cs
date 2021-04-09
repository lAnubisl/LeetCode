using System;

namespace LeetCode2AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = AddTwoNumbers(
                new ListNode(2, new ListNode(4, new ListNode(3, null))),
                new ListNode(5, new ListNode(6, new ListNode(4, null))));
            Console.WriteLine("Hello World!");
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            var current = result;
            bool save = false;
            do
            {
                int one = 0;
                if (l1 != null)
                {
                    one = l1.val;
                    l1 = l1.next;
                }
                int other = 0;
                if (l2 != null)
                {
                    other = l2.val;
                    l2 = l2.next;
                }
                var digit = one + other + (save ? 1 : 0);
                save = false;
                if (digit > 9)
                {
                    digit = digit - 10;
                    save = true;
                }
                var next = new ListNode(digit);
                current.next = next;
                current = next;
            }
            while (l1 != null || l2 != null);

            if (save)
            {
                current.next = new ListNode(1);
            }

            return result.next;
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
