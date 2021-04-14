using System;
using System.Collections.Generic;

namespace LeetCode6ZigZagConversion
{
    /*
    
    The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
    (you may want to display this pattern in a fixed font for better legibility)
    P   A   H   N
    A P L S I I G
    Y   I   R

    And then read line by line: "PAHNAPLSIIGYIR"
    Write the code that will take a string and make this conversion given a number of rows:
    
    string convert(string s, int numRows);

    Example 1:
    Input: s = "PAYPALISHIRING", numRows = 3
    Output: "PAHNAPLSIIGYIR"
    Explanation:
    P   A   H   N
    A P L S I I G
    Y   I   R

    Example 2:
    Input: s = "PAYPALISHIRING", numRows = 4
    Output: "PINALSIGYAHRPI"
    Explanation:
    P     I    N
    A   L S  I G
    Y A   H R
    P     I

    Example 3:
    Input: s = "A", numRows = 1
    Output: "A"

    Constraints:
        1 <= s.length <= 1000
        s consists of English letters (lower-case and upper-case), ',' and '.'.
        1 <= numRows <= 1000 
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 3));
        }

        public static string Convert(string s, int numRows) 
        {
            if (numRows < 1) throw new ArgumentException(nameof(numRows));
            if (numRows == 1) return s;           
            return string.Join("", Generate(s, numRows));
        }

        private static IEnumerable<char> Generate(string s, int rowsTotal)
        {
            for(int rowNo = 1; rowNo <= rowsTotal; rowNo++)
            for(int letterNo = rowNo; letterNo <= s.Length; letterNo += IncIndex(letterNo, rowsTotal))
            yield return s[letterNo - 1];
        }

        private static int IncIndex(int letterNo, int rowsTotal)
        {
            int step = rowsTotal - 1;
            int position = letterNo % step;
            int diff = rowsTotal - position;
            if (diff == 0) return 2 * step;
            if (position == 0) return 2;
            return 2 * diff;
        } 
    }
}
