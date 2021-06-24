using Xunit;

namespace Solutions.longest_valid_parentheses
{
    public class UnitTests
    {
        [Theory]
        [InlineData("(()", 2)]
        [InlineData(")()())", 4)]
        [InlineData("", 0)]
        [InlineData("()(()", 2)]
        public void SolutionReturnsLengthOfLongestValidParenthesesString(string s, int expectedOutput)
        {
            // Arrange
            var solution = new Solution();

            // Act
            int output = solution.LongestValidParentheses(s);

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
