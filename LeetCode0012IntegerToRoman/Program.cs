using System;
using System.Text;

namespace LeetCode0012IntegerToRoman
{
    /*
        Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
        Symbol       Value
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000

        For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
        Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
            I can be placed before V (5) and X (10) to make 4 and 9. 
            X can be placed before L (50) and C (100) to make 40 and 90. 
            C can be placed before D (500) and M (1000) to make 400 and 900.
        Given an integer, convert it to a roman numeral.

        Example 1:
        Input: num = 3
        Output: "III"

        Example 2:
        Input: num = 4
        Output: "IV"

        Example 3:
        Input: num = 9
        Output: "IX"

        Example 4:
        Input: num = 58
        Output: "LVIII"
        Explanation: L = 50, V = 5, III = 3.

        Example 5:
        Input: num = 1994
        Output: "MCMXCIV"
        Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

        Constraints:
        1 <= num <= 3999
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IntToRoman(1994));
        }

        public static string IntToRoman(int num) 
        {
            StringBuilder sb = new StringBuilder();
            while (num > 0)
            {
                if (Check(ref num, 1000, "M", sb)) continue;
                if (Check(ref num, 900, "CM", sb)) continue;
                if (Check(ref num, 500,  "D", sb)) continue;
                if (Check(ref num, 400, "CD", sb)) continue;
                if (Check(ref num, 100,  "C", sb)) continue;
                if (Check(ref num, 90,  "XC", sb)) continue;
                if (Check(ref num, 50,   "L", sb)) continue;
                if (Check(ref num, 40,  "XL", sb)) continue;
                if (Check(ref num, 10,   "X", sb)) continue;
                if (Check(ref num, 9,   "IX", sb)) continue;
                if (Check(ref num, 5,    "V", sb)) continue;
                if (Check(ref num, 4,   "IV", sb)) continue;
                if (Check(ref num, 1,    "I", sb)) continue;
            }
            return sb.ToString();
        }

        private static bool Check(ref int num, int check, string val, StringBuilder sb)
        {
            if (num < check) return false;
            sb.Append(val);
            num-=check;
            return true;
        }
    }
}
