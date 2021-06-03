using System;

namespace LeetCode0029_divide_two_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Divide(-2147483648, 2) + " " + (-2147483648 / 2));
            Console.WriteLine(Divide(10, 3) + " " + (10 / 3));
            Console.WriteLine(Divide(2147483647, 2) + " " + (2147483647 / 2));
            Console.WriteLine(Divide(2147483647, 3) + " " + (2147483647 / 3));
        }

        public static int Divide(int dividend, int divisor)
        {
            if (dividend == int.MinValue && divisor == -1) return int.MaxValue;
            bool negativeResult = dividend > 0 ^ divisor > 0;
            int negativeDividend = negative(dividend), negativeDivisor = negative(divisor), result = 0;
            while(negativeDividend <= negativeDivisor)
            {
                int divisorBinaryShifted = negativeDivisor, binaryShifts = 0, temp = divisorBinaryShifted;
                while(negativeDividend <= (temp <<= 1) && temp <= 0) 
                {
                    divisorBinaryShifted = temp;
                    binaryShifts++;
                }
                    
                negativeDividend -= divisorBinaryShifted;
                result += 1 << binaryShifts;
            }

            return negativeResult ? negative(result) : result;
        }

        private static int negative(int x)
        {
            if (x < 0) return x;
            var y = -1 >> 31;
            return (x + y) ^ y;
        }
    }
}
