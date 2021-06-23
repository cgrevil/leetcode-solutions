using System;
using System.Threading.Tasks;
using Xunit;

namespace Solutions.print_foobar_alternately
{

    public class UnitTests
    {
        [Theory]
        [InlineData(1, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(2, false)]
        [InlineData(100, true)]
        [InlineData(100, false)]
        public async Task FooBarPrintsCorrectlyWhenCalledFromMultipleThreadsTheory(int n, bool isFooThreadStartedFirst)
        {
            // Arrange
            string printed = "";
            var foobar = new FooBar(n);

            Action printBar = () => printed += "bar";
            Action printFoo = () => printed += "foo";

            // Act
            Task fooThread;
            Task barThread;
            
            if (isFooThreadStartedFirst)
            {
                fooThread = Task.Factory.StartNew(() => foobar.Foo(printFoo));
                await Task.Delay(10);
                barThread = Task.Factory.StartNew(() => foobar.Bar(printBar));
            }
            else
            {
                barThread = Task.Factory.StartNew(() => foobar.Bar(printBar));
                await Task.Delay(10);
                fooThread = Task.Factory.StartNew(() => foobar.Foo(printFoo));
            }

            await Task.WhenAll(new[]
            {
                fooThread,
                barThread,
            });

            // Assert
            string expected = "";
            for (int i = 0; i < n; i++)
            {
                expected += "foobar";
            }
            Assert.Equal(expected, printed);
        }
    }
}
