using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.median_of_two_sorted_arrays
{
    /// <summary>
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/
    /// </summary>
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Edgecase 1a: No elements in nums1
            if (nums1.Length == 0)
                return FindMedianSortedArray(nums2);

            // Edgecase 1b: No elements in nums2
            if (nums2.Length == 0)
                return FindMedianSortedArray(nums1);

            // To find the median we can partition the combined array into left, middle, and right, where left and right are of same size, and middle is 1 or 2 elements. Since the two arrays are sorted, the left partition must consist of a) zero or more elements from the beginning of nums1 together, and b) zero or more from beginning of nums2. Our strategy is to find the number of elements in the left partition that comes from nums1. Then we can calculate the median in constant time.
            int leftPartitionSize = (nums1.Length + nums2.Length - 1) / 2;
            int from1Min = Math.Max(0, leftPartitionSize - nums2.Length);
            int from1Max = Math.Min(nums1.Length, leftPartitionSize);

            int from1 = FindLeftMedianPartitionRecursive(leftPartitionSize, from1Min, from1Max, nums1, nums2);
            int from2 = leftPartitionSize - from1;

            bool totalLengthIsEven = (nums1.Length + nums2.Length) % 2 == 0;
            if (totalLengthIsEven)
            {
                var candidates = new List<int>();
                candidates.AddRange(nums1.Skip(from1).Take(2));
                candidates.AddRange(nums2.Skip(from2).Take(2));
                candidates.Sort();
                return candidates.Take(2).Sum() / 2.0;
            }
            else
            {
                var candidates = new List<int>();
                candidates.AddRange(nums1.Skip(from1).Take(1));
                candidates.AddRange(nums2.Skip(from2).Take(1));
                candidates.Sort();
                return candidates.First();
            }
        }

        private double FindMedianSortedArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            if (nums.Length % 2 == 0)
            {
                int a = nums[nums.Length / 2 - 1];
                int b = nums[nums.Length / 2];
                return (a + b) / 2.0;
            }

            return nums[nums.Length / 2];
        }

        private int FindLeftMedianPartitionRecursive(int leftPartitionSize, int from1Min, int from1Max, int[] nums1, int[] nums2)
        {
            int from1 = from1Min + (from1Max - from1Min) / 2;
            int from2 = leftPartitionSize - from1;

            int? left1 = from1 > 0 ? nums1[from1 - 1] : default(int?);
            int? left2 = from2 > 0 ? nums2[from2 - 1] : default(int?);
            int? right1 = from1 < nums1.Length ? nums1[from1] : default(int?);
            int? right2 = from2 < nums2.Length ? nums2[from2] : default(int?);

            bool tooManyFrom1 = left1.HasValue && right2.HasValue && left1.Value > right2.Value;
            bool tooFewFrom1 = left2.HasValue && right1.HasValue && left2.Value > right1.Value;

            if (tooManyFrom1)
            {
                // Recursive step: Binary search for valid partition
                return FindLeftMedianPartitionRecursive(leftPartitionSize, from1Min, from1 - 1, nums1, nums2);
            }
            if (tooFewFrom1)
            {
                // Recursive step: Binary search for valid partition
                return FindLeftMedianPartitionRecursive(leftPartitionSize, from1 + 1, from1Max, nums1, nums2);
            }

            // Base case: Current partition is valid
            return from1;
        }
    }
}
