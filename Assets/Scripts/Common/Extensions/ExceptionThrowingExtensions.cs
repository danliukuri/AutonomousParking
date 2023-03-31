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

        public static int ThrowExceptionIfArgumentOutOfRange<T>(this int argument, string argumentName,
            ICollection<T> collection) =>
            argument.ThrowExceptionIfArgumentOutOfRange(argumentName, collection.FirstIndex(), collection.LastIndex());

        public static T ThrowExceptionIfArgumentOutOfRange<T>(this T argument, string argumentName,
            T minValue, T maxValue) where T : IComparable<T>
        {
            if (argument.CompareTo(minValue) < (int)default)
                throw new ArgumentOutOfRangeException(argumentName, $"Value cannot be less than {minValue}.");
            if (argument.CompareTo(maxValue) > (int)default)
                throw new ArgumentOutOfRangeException(argumentName, $"Value cannot be greater than {maxValue}.");
            return argument;
        }

        public static IEnumerable<T> ThrowExceptionIfNoElements<T>(this IEnumerable<T> source)
        {
            if (!source.Any())
                throw new InvalidOperationException("Sequence contains no elements");
            return source;
        }
    }
}