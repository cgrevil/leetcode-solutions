using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Solutions.print_foobar_alternately
{

    public class UnitTests
    {
        [Fact]
        public void FooBar_WhenNIs1AndBarFooIsCalled_PrintsFooBarOnce()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Bar(() => print += "bar");
            foobar.Foo(() => print += "foo");

            // Assert
            Assert.Equal("foobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs1AndFooBarIsCalled_PrintsFooBarOnce()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");

            // Assert
            Assert.Equal("foobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs2AndBarFooBarFooIsCalled_PrintsFooBarTwice()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Bar(() => print += "bar");
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");
            foobar.Foo(() => print += "foo");

            // Assert
            Assert.Equal("foobarfoobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs2AndFooBarBarFooIsCalled_PrintsFooBarTwice()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");
            foobar.Bar(() => print += "bar");
            foobar.Foo(() => print += "foo");

            // Assert
            Assert.Equal("foobarfoobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs2AndFooFooBarBarIsCalled_PrintsFooBarTwice()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Foo(() => print += "foo");
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");
            foobar.Bar(() => print += "bar");

            // Assert
            Assert.Equal("foobarfoobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs2AndFooBarFooBarIsCalled_PrintsFooBarTwice()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Foo(() => print += "foo");
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");
            foobar.Bar(() => print += "bar");

            // Assert
            Assert.Equal("foobarfoobar", print);
        }

        [Fact]
        public void FooBar_WhenNIs2AndBarFooFooBarIsCalled_PrintsFooBarTwice()
        {
            // Arrange
            string print = "";
            var foobar = new FooBar(1);

            // Act
            foobar.Bar(() => print += "bar");
            foobar.Foo(() => print += "foo");
            foobar.Foo(() => print += "foo");
            foobar.Bar(() => print += "bar");

            // Assert
            Assert.Equal("foobarfoobar", print);
        }
    }
}
