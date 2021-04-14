using System;

namespace LeetCode0007ReverseInteger
{
    /*
    Given a signed 32-bit integer x, return x with its digits reversed. 
    If reversing x causes the value to go outside the signed 32-bit integer range [-2**31, 2**31 - 1], then return 0.
    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

    Example 1:
    Input: x = 123
    Output: 321

    Example 2:
    Input: x = -123
    Output: -321

    Example 3:
    Input: x = 120
    Output: 21

    Example 4:
    Input: x = 0
    Output: 0

    Constraints:
    -231 <= x <= 231 - 1
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(2147483647));
            Console.WriteLine(Reverse(1534236469));
                                //    9646324351
        }

        public static int Reverse(int x) 
        {
            var inversed = ReverseInner(x).Item1;
            return ReverseInner(x).Item1;
        }

        private static (int, int) ReverseInner(int x)
        {
            if (x < 10 && x > -10)
            {
                return (x, 10);
            }

            var tail = x % 10;
            var deep = ReverseInner(x / 10);

            if (x > 0 && (int.MaxValue / deep.Item2 < tail || int.MinValue - deep.Item1 < tail * deep.Item2))
            {
                return (0, 0);
            }

            if (x < 0 && (int.MinValue / deep.Item2 > tail || int.MinValue - deep.Item1 > tail * deep.Item2))
            {
                return (0, 0);
            }

            return (tail * deep.Item2 + deep.Item1, deep.Item2 * 10);
        }
    }
}
