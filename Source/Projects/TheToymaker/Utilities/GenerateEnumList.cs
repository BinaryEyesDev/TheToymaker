using System;
using System.Collections.Generic;

namespace TheToymaker.Utilities
{
    public static class GenerateEnumList
    {
        public static List<T> Perform<T>()
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"requested type is not an enum: {typeof(T).Name}");

            var list = new List<T>();
            var valueArray = Enum.GetValues(typeof(T));
            foreach (var value in valueArray)
                list.Add((T) value);

            return list;
        }
    }
}
