using System;
using System.Collections.Generic;

namespace AutomaticParking.Common.Extensions
{
    public static class ExceptionThrowingExtensions
    {
        public static T ThrowExceptionIfArgumentIsNull<T>(this T argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);
            return argument;
        }

        public static IReadOnlyCollection<T> ThrowExceptionIfNoElements<T>(this IReadOnlyCollection<T> argument)
        {
            if (argument.Count == default)
                throw new InvalidOperationException("Sequence contains no elements");
            return argument;
        }

        public static T ThrowExceptionIfArgumentOutOfRange<T>(this T argument, string argumentName,
            T minValue, T maxValue) where T : IComparable<T>
        {
            if (argument.CompareTo(minValue) < (int)default)
                throw new ArgumentOutOfRangeException(argumentName, $"Value cannot be less than {minValue}.");
            if (argument.CompareTo(maxValue) > (int)default)
                throw new ArgumentOutOfRangeException(argumentName, $"Value cannot be greater than {maxValue}.");
            return argument;
        }
    }
}