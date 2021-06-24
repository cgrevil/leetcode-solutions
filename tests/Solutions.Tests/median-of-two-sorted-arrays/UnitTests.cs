using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Solutions.median_of_two_sorted_arrays
{
    public class UnitTests
    {
        [Theory]
        [InlineData("1,3", "2", 2.0)]
        [InlineData("1,2", "3,4", 2.5)]
        [InlineData("0,0", "0,0", 0.0)]
        [InlineData("", "1", 1.0)]
        [InlineData("2", "", 2.0)]
        public void SolutionFindsTheMedianOfSortedArraysTheory(string nums1String, string nums2String, double expectedOutput)
        {
            // Arrange
            var nums1 = ParseNumString(nums1String);
            var nums2 = ParseNumString(nums2String);
            
            var solution = new Solution();

            // Act
            double output = solution.FindMedianSortedArrays(nums1, nums2);

            // Assert
            Assert.Equal(expectedOutput, output);
        }

        private static int[] ParseNumString(string numsString)
        {
            return numsString
                .Split(",")
                .Where(s => s != "")
                .Select(n => int.Parse(n))
                .ToArray();
        }
    }
}
