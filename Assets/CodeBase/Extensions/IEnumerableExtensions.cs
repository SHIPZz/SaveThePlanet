using System;
using System.Collections.Generic;

namespace CodeBase.Extensions
{
    public static class IEnumerableExtensions
    {
        private static Random rng = new Random();

        public static IEnumerable<T> Shuffle<T>(this List<T> source)
        {
            var elements = source;
            int n = elements.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = elements[k];
                elements[k] = elements[n];
                elements[n] = value;
            }

            return elements;
        }
    }
}