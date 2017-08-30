using System;
using System.Threading;

namespace CoreUtilities
{
    public static class ThreadUtility
    {
        public static System.Threading.Thread Repeat(TimeSpan interval,
                    Action action, string name = "MyThread", bool isBackground = false)
        {
            var thread = new System.Threading.Thread(() => new Timer(obj => action(), null, TimeSpan.Zero, interval))
            {
                IsBackground = isBackground,
                Name = name
            };
            return thread;
        }

        public static System.Threading.Thread Repeat(TimeSpan interval,
                    Action action, Func<bool> stopWhen, string name = "MyThread", bool isBackground = false)
        {
            var thread = new System.Threading.Thread(() =>
            {
                var timer = new Timer(obj => { action(); }, null, TimeSpan.Zero, interval);
                if (stopWhen())
                {
                    timer.Dispose();
                }
            })
            {
                IsBackground = isBackground,
                Name = name
            };
            return thread;
        }
    }
}
