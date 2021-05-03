using System;
using System.Collections.Generic;

namespace LeetCode0020ValidParentheses
{
    /*
    
        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.

        Example 1:
        Input: s = "()"
        Output: true

        Example 2:
        Input: s = "()[]{}"
        Output: true

        Example 3:
        Input: s = "(]"
        Output: false

        Example 4:
        Input: s = "([)]"
        Output: false

        Example 5:
        Input: s = "{[]}"
        Output: true

        Constraints:
            1 <= s.length <= 104
            s consists of parentheses only '()[]{}'.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("{[]}"));
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '[': stack.Push(c); break;
                    case ']': if (!Check(stack, '[')) { return false; }; break;
                    case '(': stack.Push(c); break;
                    case ')': if (!Check(stack, '(')) { return false; }; break;
                    case '{': stack.Push(c); break;
                    case '}': if (!Check(stack, '{')) { return false; }; break;
                }
            }

            return !stack.TryPeek(out char foo);
        }

        private static bool Check(Stack<char> stack, char c)
        {
            if (stack.TryPeek(out char x) && x == c)
            {
                stack.Pop();
                return true;
            }

            return false;
        }
    }
}
