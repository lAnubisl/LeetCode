using System;

namespace LeetCode4MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindMedianSortedArrays(new int[] { 2 }, new int[] { }));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i1 = 0;
            int i2 = 0;
            int totalItems = nums1.Length + nums2.Length;
            bool totalItemsOdd = totalItems % 2 == 1;
            int medianIndex = (totalItemsOdd ? (totalItems + 1) / 2 : (totalItems / 2) + 1) - 1;
            int current = 0;
            int previous = 0;
            while (i1 + i2 <= medianIndex)
            {
                if (i1 == nums1.Length)
                {
                    previous = current;
                    current = nums2[i2];
                    i2++;
                    continue;
                }
                if (i2 == nums2.Length)
                {
                    previous = current;
                    current = nums1[i1];
                    i1++;
                    continue;
                }

                if (nums1[i1] < nums2[i2])
                {
                    previous = current;
                    current = nums1[i1];
                    i1++;
                    continue;
                }

                previous = current;
                current = nums2[i2];
                i2++;
            }

            return totalItemsOdd ? current : (current + previous) / 2d;
        }
    }
}
