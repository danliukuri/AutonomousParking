using System;

namespace AutomaticParking.Common.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsLessThan<T>(this T value, T other) where T : IComparable<T> =>
            value.CompareTo(other) < default(int);
    }
}