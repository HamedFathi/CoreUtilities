using CoreExtensions;
using System;

namespace CoreUtilities
{
    public static class RandomUtility
    {
        public static DateTime GetRandomDateTime(DateTime? startDataTime = null, DateTime? endDataTime = null)
        {
            return new RandomDateTime(startDataTime, endDataTime).Next();
        }

        public static System.Random GetUniqueRandom()
        {
            return new System.Random(Guid.NewGuid().GetHashCode());
        }
    }
}
