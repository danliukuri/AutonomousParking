using System;
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


        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
            where TKey : IComparable<TKey> => ExtremumBy(source, keySelector, (key1, key2) => key1.IsLessThan(key2));

        public static TSource ExtremumBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TKey, TKey, bool> predicate) where TKey : IComparable<TKey>
        {
            source.ThrowExceptionIfArgumentIsNull(nameof(source)).ThrowExceptionIfNoElements();
            keySelector.ThrowExceptionIfArgumentIsNull(nameof(keySelector));

            using IEnumerator<TSource> enumerator = source.GetEnumerator();

            (TSource Value, TKey Key) extremum = enumerator.IterateToFirstItemWithNotNullKey(keySelector);
            while (enumerator.MoveNext())
            {
                (TSource Value, TKey Key) item = (enumerator.Current, keySelector(enumerator.Current));
                if (item.Key != null && predicate(item.Key, extremum.Key))
                    extremum = item;
            }

            return extremum.Value;
        }

        public static (TSource Value, TKey Key) IterateToFirstItemWithNotNullKey<TSource, TKey>(
            this IEnumerator<TSource> enumerator, Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
        {
            enumerator.ThrowExceptionIfArgumentIsNull(nameof(enumerator));
            keySelector.ThrowExceptionIfArgumentIsNull(nameof(keySelector));

            enumerator.MoveNext();
            (TSource Value, TKey Key) item = (enumerator.Current, keySelector(enumerator.Current));
            if (default(TKey) is null)
                while (enumerator.MoveNext() && item.Key == null)
                    item = (enumerator.Current, keySelector(enumerator.Current));
            return item;
        }
    }
}