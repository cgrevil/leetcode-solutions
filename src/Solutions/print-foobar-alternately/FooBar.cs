using System;
using System.Threading;

namespace Solutions.print_foobar_alternately
{
    /// <summary>
    /// https://leetcode.com/problems/print_foobar_alternately/
    /// </summary>
    public class FooBar
    {
        private int n;
        private SemaphoreSlim fooSemaphore;
        private SemaphoreSlim barSemaphore;

        public FooBar(int n)
        {
            this.n = n;
            this.fooSemaphore = new SemaphoreSlim(1);
            this.barSemaphore = new SemaphoreSlim(0);
        }

        public void Foo(Action printFoo)
        {
            for (int i = 0; i < n; i++)
            {
                fooSemaphore.Wait();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
                barSemaphore.Release();
            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                barSemaphore.Wait();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
                fooSemaphore.Release();
            }
        }
    }
}
