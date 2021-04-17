using System;
using System.Collections.Generic;

namespace LeetCode0015_3SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ThreeSum(new int[] {7,-1,14,-12,-8,7,2,-15,8,8,-8,-14,-4,-5,7,9,11,-4,-15,-6,1,-14,4,3,10,-5,2,1,6,11,2,-2,-5,-7,-6,2,-15,11,-6,8,-4,2,1,-1,4,-6,-15,1,5,-15,10,14,9,-8,-6,4,-6,11,12,-15,7,-1,-9,9,-1,0,-4,-1,-12,-2,14,-9,7,0,-3,-4,1,-2,12,14,-10,0,5,14,-1,14,3,8,10,-8,8,-5,-2,6,-11,12,13,-7,-12,8,6,-13,14,-2,-5,-11,1,3,-6});
            Console.WriteLine();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for(int i = 0; i< nums.Length; i++)
            {
                int target = -nums[i];          // sum of 2nd and 3rd
                int left = i+1;                 // 2nd triple entry scan boundary
                int right = nums.Length - 1;    // 3rd triple entry scan boundary
                while(left < right)
                {
                    int leftVal = nums[left];
                    int rightVal = nums[right];
                    int sum = leftVal + rightVal;
                    if (sum == target)
                    {
                        res.Add(new List<int>(){nums[i], nums[left], nums[right]});
                    }
                    if (sum <= target)
                    {
                        // Skip all duplicated 2nd triple entry values
                        while(left < right && nums[left] == leftVal) left++;
                    }
                    if (sum >= target)
                    {
                        // Skip all duplicated 3rd triple entry values
                        while(left < right && nums[right] == rightVal) right--;
                    }
                }

                // Skip all duplicated 1st triple entry values
                while(i+1 < nums.Length && nums[i+1] == nums[i]) i++;
            }

            return res;
        }
    }
}