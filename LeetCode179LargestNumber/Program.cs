using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LeetCode179LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new[] { 0, 0 };
            Console.WriteLine(Solve(input));
        }

        static string Solve(int[] nums)
        {
            var ordered = nums.OrderByDescending(i => i, new Comparer());
            if (ordered.First() == 0) return "0";
            return string.Join(string.Empty, ordered.Select(i => i.ToString()));
        }
    }

    public class Comparer : IComparer<int>
    {
        static int GetDigits(int val)
        {
            if (val == 0) return 1;
            float fVal = (float)val;
            int digits = 0;
            while (fVal >= 1)
            {
                fVal = fVal / 10;
                digits++;
            }

            return digits;
        }

        public int Compare(int x, int y)
        {
            return x * Math.Pow(10, GetDigits(y)) + y > y * Math.Pow(10, GetDigits(x)) + x ? 1 : -1;
        }
    }
}
