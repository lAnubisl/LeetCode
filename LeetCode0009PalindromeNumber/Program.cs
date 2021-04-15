using System;

namespace LeetCode0009PalindromeNumber
{
    class Program
    {
        /*
            Given an integer x, return true if x is palindrome integer.

            An integer is a palindrome when it reads the same backward as forward. For example, 121 is palindrome while 123 is not.
            Example 1:
            Input: x = 121
            Output: true

            Example 2:
            Input: x = -121
            Output: false
            Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

            Example 3:
            Input: x = 10
            Output: false
            Explanation: Reads 01 from right to left. Therefore it is not a palindrome.

            Example 4:
            Input: x = -101
            Output: false

            Constraints:
                -231 <= x <= 231 - 1   
            Follow up: Could you solve it without converting the integer to a string?
        */
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome(121));
        }
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            return IsPolyndrome(ToDigitArray(x));
        }


        private static bool IsPolyndrome(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                if (arr[left] != arr[right]) return false;
                left++;
                right--;
            }

            return true;
        }

        private static int[] ToDigitArray(int x)
        {
            int[] arr = new int[GetRank(x)];
            for(int i = arr.Length - 1; i >=0; i--)
            {
                arr[i] = x % 10;
                x = x / 10;
            }

            return arr;
        }
        private static int GetRank(int x)
        {
            int rank = 0;
            while(x > 9)
            {
                x = x / 10;
                rank++;
            }

            return rank + 1;
        }
    }
}
