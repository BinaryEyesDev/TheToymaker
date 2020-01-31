using System;

namespace TheToymaker.Utilities
{
    public static class GetRandom
    {
        public static float Float(float min, float max)
        {
            var range = max - min;
            var point = (float) _rng.NextDouble();
            return min + point*range;
        }

        public static int Int(int min, int max)
        {
            return _rng.Next(min, max);
        }

        static GetRandom()
        {
            _rng = new Random();
        }

        private static readonly Random _rng;
    }
}
