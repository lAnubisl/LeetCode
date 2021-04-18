using System;

namespace LeetCode0016_3SUMClosest
{

    /*
    
    Given an array nums of n integers and an integer target, find three integers in nums such that 
    the sum is closest to target. Return the sum of the three integers. You may assume that each input 
    would have exactly one solution.

    Example 1:

    Input: nums = [-1,2,1,-4], target = 1
    Output: 2
    Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

    Constraints:

        3 <= nums.length <= 10^3
        -10^3 <= nums[i] <= 10^3
        -10^4 <= target <= 10^4
    
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ThreeSumClosest(new int[]{-100, -98 , -2, -1}, -101));
            Console.WriteLine(ThreeSumClosest(new int[]{0, 1, 2}, 3));
            Console.WriteLine(ThreeSumClosest(new int[]{-1,2,1,-4}, 1));
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int closest = nums[0] + nums[1] + nums[2];
            for(int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while(left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    int diff = target - sum;
                    if (Math.Abs(diff) < Math.Abs(target - closest))
                    closest = sum;
                    if (closest == target) return closest;
                    if (diff < 0)
                    {
                        do { right--; }
                        while(left < right && nums[right] == nums[right + 1]);
                    }
                    if (diff > 0)
                    {
                        do { left++; }
                        while(left < right && nums[left] == nums[left - 1]);
                    }
                }
            }

            return closest;
        }
    }
}
