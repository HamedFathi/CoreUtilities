using System;
using System.Collections.Generic;
using System.Reflection;

namespace CoreUtilities
{
    public static class EnumUtility<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<string> GetNames()
        {
            var t = typeof(T);
            if (!t.GetTypeInfo().IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");
            return System.Enum.GetNames(typeof(T));
        }

        public static IEnumerable<int> GetValues()
        {
            var t = typeof(T);
            if (!t.GetTypeInfo().IsEnum)
                throw new ArgumentException("Type provided must be an Enum.", "T");
            var types = System.Enum.GetValues(typeof(T));
            var nums = new List<int>();
            foreach (var type in types)
            {
                nums.Add((int)type);
            }
            return nums;
        }
    }
}
