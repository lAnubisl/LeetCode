using System;

namespace LeetCode0010RegularExpressionMatching
{
    /*
        Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where: 
            '.' Matches any single character.​​​​
            '*' Matches zero or more of the preceding element.
        The matching should cover the entire input string (not partial).

        Example 1:
        Input: s = "aa", p = "a"
        Output: false
        Explanation: "a" does not match the entire string "aa".

        Example 2:
        Input: s = "aa", p = "a*"
        Output: true
        Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

        Example 3:
        Input: s = "ab", p = ".*"
        Output: true
        Explanation: ".*" means "zero or more (*) of any character (.)".

        Example 4:
        Input: s = "aab", p = "c*a*b"
        Output: true
        Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".

        Example 5:
        Input: s = "mississippi", p = "mis*is*p*."
        Output: false

        Constraints:
            0 <= s.length <= 20
            0 <= p.length <= 30
            s contains only lowercase English letters.
            p contains only lowercase English letters, '.', and '*'.
            It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsMatch("bbbba", ".*a*a"));
            Console.WriteLine(IsMatch("aaa", "a*a"));
            Console.WriteLine(IsMatch("aab", "c*a*b"));
        }

        public static bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, 0, 0);
        }

        public static bool IsMatch(string s, string p, int s_i, int p_i)
        {
            while(s_i < s.Length && p_i < p.Length)
            {
                if (s[s_i] == p[p_i] || p[p_i] == '.') // current symbol matches
                {
                    if (p_i + 1 >= p.Length || p[p_i + 1] != '*') // not 'starred' symbol
                    {
                        s_i++;
                        p_i++;
                        continue;
                    }

                    if (IsMatch(s, p, s_i, p_i + 2)) // calculate case with skipping 'starred' symbol
                    {
                        return true;
                    }

                    s_i++; // 'starred' symbol case. stay at same position in pattern but be ready to skip it next
                    continue;
                }

                if (p_i + 1 < p.Length && p[p_i + 1] == '*') // skip 'starred' symbol
                {
                    p_i+=2;
                    continue;
                }

                return false;
            }

            if (p_i == p.Length && s_i < s.Length) 
            {
                return false;
            }

            if (p_i == p.Length && s_i == s.Length) 
            {
                return true;
            }

            while(p_i < p.Length)
            {
                if (p_i + 1 < p.Length && p[p_i + 1] == '*')
                {
                    p_i += 2;
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}
