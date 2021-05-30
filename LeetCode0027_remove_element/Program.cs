using System;

namespace LeetCode0027_remove_element
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]{0,1,2,2,3,0,4,2};
            var res = RemoveElement(nums, 2);
            Console.WriteLine("Hello World!");
        }

        public static int RemoveElement(int[] nums, int val) 
        {
            int rightEdge = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    continue;
                }

                nums[rightEdge] = nums[i];
                rightEdge++;
            }

            return rightEdge;
        }
    }
}
