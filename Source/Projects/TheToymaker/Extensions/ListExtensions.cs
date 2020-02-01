using System.Collections.Generic;

namespace TheToymaker.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> list)
        {
            var index = Utilities.GetRandom.Int(0, list.Count);
            return list[index];
        }
    }
}
