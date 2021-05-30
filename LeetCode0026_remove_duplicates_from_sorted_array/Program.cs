using System;

namespace LeetCode0026_remove_duplicates_from_sorted_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 0,0,1,1,1,2,2,3,3,4 };
            int len = RemoveDuplicates(nums);
            Console.WriteLine("Hello World!");
        }

        public static int RemoveDuplicates(int[] nums) 
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }

            int rightEdge = 0;
            for(int i=1; i<nums.Length; i++)
            {
                if (nums[i] == nums[rightEdge])
                {
                    continue;
                }

                rightEdge++;
                nums[rightEdge] = nums[i];
            }

            return rightEdge + 1;
        }
    }
}
