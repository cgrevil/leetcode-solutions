using Xunit;

namespace Solutions.strong_password_checker
{
    public class UnitTests
    {
        private readonly Solution _solution;

        public UnitTests()
        {
            _solution = new Solution();
        }

        [Fact]
        public void Example1()
        {
            Assert.Equal(5, _solution.StrongPasswordChecker("a"));
        }

        [Fact]
        public void Example2()
        {
            Assert.Equal(3, _solution.StrongPasswordChecker("aA1"));
        }

        [Fact]
        public void Example3()
        {
            Assert.Equal(0, _solution.StrongPasswordChecker("1337C0d3"));
        }

        [Fact]
        public void Example4()
        {
            Assert.Equal(2, _solution.StrongPasswordChecker("aaa111"));
        }

        [Fact]
        public void Example5()
        {
            Assert.Equal(8, _solution.StrongPasswordChecker("bbaaaaaaaaaaaaaaacccccc"));
        }
    }
}
