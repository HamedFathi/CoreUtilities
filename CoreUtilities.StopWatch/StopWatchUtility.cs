using System;
using System.Diagnostics;

namespace CoreUtilities
{
    public static class StopWatchUtility
    {
        public static long GetExcecutionTime(Action action)
        {
            var start = new Stopwatch();

            start.Start();
            action();
            start.Stop();
            var time = start.ElapsedMilliseconds;
            Debug.WriteLine("{0}ms, {1}s, {2}m", time, TimeSpan.FromMilliseconds(time).TotalSeconds,
                Math.Round(TimeSpan.FromMilliseconds(time).TotalMinutes, 6));
            return time;
        }

        public static long GetExcecutionTime(string name, Action action)
        {
            var start = new Stopwatch();

            start.Start();
            action();
            start.Stop();
            var time = start.ElapsedMilliseconds;
            Debug.WriteLine("{0} : {1}ms, {2}s, {3}m", name, time, TimeSpan.FromMilliseconds(time).TotalSeconds,
                Math.Round(TimeSpan.FromMilliseconds(time).TotalMinutes, 6));
            return time;
        }
    }
}
