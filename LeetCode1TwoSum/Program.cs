using System;
using System.Collections.Generic;

namespace LeetCode1TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var mums = new[] { 3, 3 };
            var target = 6;

            Console.WriteLine(string.Join(", ", Solve(mums, target)));
        }

        static int[] Solve(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    return new[] { dict[target - nums[i]], i };
                }

                dict.Add(nums[i], i);
            }

            return null;
        }
    }
}
