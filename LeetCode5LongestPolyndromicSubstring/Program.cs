using System;

namespace LeetCode5LongestPolyndromicSubstring
{
    /* Description
    Given a string s, return the longest palindromic substring in s.
    Example 1:

    Input: s = "babad"
    Output: "bab"
    Note: "aba" is also a valid answer.

    Example 2:

    Input: s = "cbbd"
    Output: "bb"

    Example 3:

    Input: s = "a"
    Output: "a"

    Example 4:

    Input: s = "ac"
    Output: "a"

    Constraints:

    1 <= s.length <= 1000
    s consist of only digits and English letters (lower-case and/or upper-case),

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindrome("ac"));
        }

        public static string LongestPalindrome(string s)
        {
            int left = 0;
            int right = 0;
            for(int i = 0; i < s.Length; i++)
            {
                var result = CheckPolyndrome(s, i);
                if (result.Item2 - result.Item1 > right - left)
                {
                    left = result.Item1;
                    right = result.Item2;
                }
            }

            return s.Substring(left, right - left + 1);
        }

        private static (int, int) CheckPolyndrome(string s, int center)
        {
            int left = center;
            int right = center;
            bool expandCenter = true;
            while(true) 
            {
                if (expandCenter)
                {
                    if(left > 0 && s[left - 1] == s[left])
                    {
                        left--;
                        continue;
                    }

                    if(right < s.Length - 1 && s[right + 1] == s[right])
                    {
                        right++;
                        continue;
                    }

                    expandCenter = false;
                }

                if (left > 0 && right < s.Length -1 && s[left - 1] == s[right + 1])
                {
                    left--;
                    right++;
                    continue;
                }

                return (left, right);
            }
        }
    }
}
