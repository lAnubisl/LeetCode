using System;

namespace LeetCode4MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays(new int[] { 2 }, new int[] { 1, 3 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1 }, new int[] { 2, 3 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 3 }, new int[] { -2, -1 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 4,5,6,8,9 }, new int[] {  }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 2 }, new int[] {  }));
            Console.WriteLine(FindMedianSortedArrays(new int[] {  }, new int[] { 1 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] {  }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 2, 3 }, new int[] { 1 }));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int totalLength = nums1.Length + nums2.Length;
            bool totalLengthEven = totalLength % 2 == 0;
            int medianPosition = (totalLengthEven ? totalLength / 2 : (totalLength + 1) / 2);
            return FindMedianSortedArrays(nums1, nums2, 0, nums1.Length < medianPosition ? nums1.Length : medianPosition, medianPosition, totalLengthEven);
        }

        private static double FindMedianSortedArrays(int[] a, int[] b, int aMin, int aMax, int medianPosition, bool awgOfTwo)
        {
            int aTake = aMin + (aMax - aMin) / 2;
            CheckResult checkResult = Check(a, b, aTake, medianPosition);
            switch(checkResult)
            {
                case CheckResult.Exact: return Calculate(a, b, aTake, medianPosition - aTake, awgOfTwo);
                case CheckResult.TooMuch: return FindMedianSortedArrays(a, b, aMin, aTake - 1, medianPosition, awgOfTwo);
                case CheckResult.NotEnough: return FindMedianSortedArrays(a, b, aTake + 1, aMax, medianPosition, awgOfTwo);
                default: throw new InvalidOperationException();
            }
        }

        private static double Calculate(int[] a, int[] b, int aTake, int bTake, bool awgOfTwo)
        {
            int current = aTake == 0
                ? b[bTake - 1]
                : bTake == 0
                    ? a[aTake - 1]
                    : a[aTake - 1] > b[bTake - 1] 
                        ? a[aTake - 1]
                        : b[bTake - 1];

            if (!awgOfTwo)
            {
                return current;
            }

            int next = a.Length == aTake 
                ? b[(bTake - 1) + 1] 
                : b.Length == bTake 
                    ? a[(aTake - 1) + 1] 
                    : a[(aTake - 1) + 1] < b[(bTake - 1) + 1] 
                        ? a[(aTake - 1) + 1]
                        : b[(bTake - 1) + 1];

            return (current + next) / 2d;
        }
        
        private static CheckResult Check(int[] a, int[] b, int aTake, int medianPosition)
        {
            int bTake = medianPosition - aTake;
            if (aTake == 0)
            {
                if (b.Length < medianPosition || (a.Length > 0 && a[0] < b[medianPosition - 1]))
                {
                    return CheckResult.NotEnough;
                }

                return CheckResult.Exact;
            }

            if (bTake == 0)
            {
                if (b.Length > 0 && b[0] < a[aTake - 1])
                {
                    return CheckResult.TooMuch;
                }

                return CheckResult.Exact;
            }

            if (b.Length > bTake && b[(bTake - 1) + 1] < a[aTake - 1])
            {
                return CheckResult.TooMuch;
            }

            if (bTake > 0 && (b.Length < bTake || (a.Length > aTake && a[(aTake - 1) + 1] < b[bTake - 1])))
            {
                return CheckResult.NotEnough;
            }

            return CheckResult.Exact;
        }
    }

    public enum CheckResult
    {
        TooMuch,
        Exact,
        NotEnough
    }
}
