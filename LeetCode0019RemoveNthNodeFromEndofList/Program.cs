using System;

namespace LeetCode0019RemoveNthNodeFromEndofList
{
    /*
        Given the head of a linked list, remove the nth node from the end of the list and return its head.
        Follow up: Could you do this in one pass?

        Example 1:
        Input: head = [1,2,3,4,5], n = 2
        Output: [1,2,3,5]

        Example 2:
        Input: head = [1], n = 1
        Output: []

        Example 3:
        Input: head = [1,2], n = 1
        Output: [1]

        Constraints:
        The number of nodes in the list is sz.
        1 <= sz <= 30
        0 <= Node.val <= 100
        1 <= n <= sz
    */
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
            var list1 = new ListNode(1, null);
            var list2 = new ListNode(1, new ListNode(2, null));
            var result = RemoveNthFromEnd(list2, 1);
            Console.WriteLine("Hello World!");
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n) 
        {
            var result = head;
            int index = -n;
            var previous = head;
            var current = head;
            var iterated = head;
            while(index < 0 && iterated != null)
            {
                iterated = iterated.next;
                index++;
            }

            if (index < 0)
            {
                return result;
            }

            while(iterated != null)
            {
                previous = current;
                current = current.next;
                iterated = iterated.next;
            }
            
            previous.next = current.next;

            if (result == current)
            {
                result = current.next;
            }

            return result;
        }
    }


    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
}
