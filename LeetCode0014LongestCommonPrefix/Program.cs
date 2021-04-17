using System;

namespace LeetCode0014LongestCommonPrefix
{
    /*

    Write a function to find the longest common prefix string amongst an array of strings.
    If there is no common prefix, return an empty string "".

    Example 1:
    Input: strs = ["flower","flow","flight"]
    Output: "fl"

    Example 2:
    Input: strs = ["dog","racecar","car"]
    Output: ""
    Explanation: There is no common prefix among the input strings.

    Constraints:

        0 <= strs.length <= 200
        0 <= strs[i].length <= 200
        strs[i] consists of only lower-case English letters.

    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestCommonPrefix(new string[]{"flower","flow","flight"}));
        }

        public static string LongestCommonPrefix(string[] strs) 
        {
            if (strs.Length == 0) return "";
            if (strs.Length == 1) return strs[0];
            int len = 0;
            while(true)
            {
                for(int i = 0; i < strs.Length; i++)
                {   
                    if (strs[i].Length == len || strs[i][len] != strs[0][len]) 
                    return strs[0].Substring(0, len);
                }
                len++;
            }
        }
    }
}
