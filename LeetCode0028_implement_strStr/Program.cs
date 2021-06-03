using System;

namespace LeetCode0028_implement_strStr
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(StrStr("a", "a"));
            Console.WriteLine(StrStr("hello", "ll"));
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            for(int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if(haystack.Substring(i, needle.Length).Equals(needle))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
