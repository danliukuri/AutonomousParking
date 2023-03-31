using System;
using System.Collections.Generic;
using System.Linq;

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

        public static IEnumerable<T> ThrowExceptionIfNoElements<T>(this IEnumerable<T> argument)
        {
            if (!argument.Any())
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