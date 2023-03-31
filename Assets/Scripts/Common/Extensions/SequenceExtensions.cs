using System.Collections.Generic;

namespace AutomaticParking.Common.Extensions
{
    public static class SequenceExtensions
    {
        public static int FirstIndex<T>(this ICollection<T> source) => default;
        public static int LastIndex<T>(this ICollection<T> source) => source.Count - 1;

        public static bool IsInIndexRange<T>(this ICollection<T> source, int index) =>
            index >= source.FirstIndex() && index < source.LastIndex();

        public static int NextInCycledRange<T>(this int index, ICollection<T> collection) =>
            collection.IsInIndexRange(index) ? index + 1 : collection.FirstIndex();

        public static IList<T> SwapItems<T>(this IList<T> source, int firstIndex, int secondIndex)
        {
            source.ThrowExceptionIfArgumentIsNull(nameof(source)).ThrowExceptionIfNoElements();
            firstIndex.ThrowExceptionIfArgumentOutOfRange(nameof(firstIndex), source);
            secondIndex.ThrowExceptionIfArgumentOutOfRange(nameof(secondIndex), source);

            if (firstIndex != secondIndex)
                (source[firstIndex], source[secondIndex]) = (source[secondIndex], source[firstIndex]);
            return source;
        }
    }
}