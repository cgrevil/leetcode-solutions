using Xunit;

namespace Solutions.regular_expression_matching
{
    public class UnitTests
    {
        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("aa", ".*", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        [InlineData("mississippi", "mis*is*.p*.", true)]
        [InlineData("a", "ab*", true)]
        public void RegularExpressionMatchingTheory(string input, string pattern, bool expectedOutput)
        {
            // Arrange
            var solution = new Solution();

            // Act
            bool output = solution.IsMatch(input, pattern);

            // Assert
            Assert.Equal(expectedOutput, output);
        }
    }
}
