using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public static class ExtensionMethods
    {
        public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
        {
            foreach (T elem in collection)
                yield return func(elem);
        }
    }
}
