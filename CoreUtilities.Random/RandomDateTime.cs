using CoreUtilities;
using System;

namespace CoreExtensions
{
    internal class RandomDateTime
    {
        DateTime _start;
        DateTime _end;
        readonly Random _gen;
        readonly int _range;

        public RandomDateTime(DateTime? startDateTime, DateTime? endDateTime)
        {
            _start = startDateTime ?? DateTime.Now.AddYears(-20);
            _end = endDateTime ?? DateTime.Now;

            _gen = RandomUtility.GetUniqueRandom();
            _range = (_end - _start).Days;
        }

        public DateTime Next()
        {
            return _start.AddDays(_gen.Next(_range)).AddHours(_gen.Next(0, 24)).AddMinutes(_gen.Next(0, 60)).AddSeconds(_gen.Next(0, 60));
        }
    }
}
