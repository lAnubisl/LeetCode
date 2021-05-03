using System;
using System.Collections.Generic;

namespace LeetCode0018_4Sum
{
    /*
        Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:
            0 <= a, b, c, d < n
            a, b, c, and d are distinct.
            nums[a] + nums[b] + nums[c] + nums[d] == target

        You may return the answer in any order.

        Example 1:
        Input: nums = [1,0,-1,0,-2,2], target = 0
        Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

        Example 2:
        Input: nums = [2,2,2,2,2], target = 8
        Output: [[2,2,2,2]]

        Constraints:
            1 <= nums.length <= 200
            -109 <= nums[i] <= 109
            -109 <= target <= 109
    */
    class Program
    {
        static void Main(string[] args)
        {
            var x = FourSum(new int[]{2,2,2,2,2}, 8);
            foreach(var item in x)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        public static IList<IList<int>> FourSum(int[] nums, int target) 
        {
            var result = new List<IList<int>>();
            if (nums.Length < 4) return result;
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    int left = j + 1;
                    int right = nums.Length - 1;
                    while(left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum == target) result.Add(new List<int>() { nums[i], nums[j], nums[left], nums[right] });
                        if (sum <= target) do { left++; } while(left < right && nums[left] == nums[left - 1]);
                        if (sum >= target) do { right--; } while(left < right && nums[right] == nums[right + 1]);
                    }

                    while(j + 1 < nums.Length && nums[j + 1] == nums[j]) j++;
                }

                while(i + 1 < nums.Length && nums[i + 1] == nums[i]) i++;
            }

            return result;
        }
    }
}
