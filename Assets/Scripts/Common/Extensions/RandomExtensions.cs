using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AutomaticParking.Common.Extensions
{
    public static class RandomExtensions
    {
        public static Vector3 RandomizeHorizontalPosition(this Vector3 position, float maxOffset) =>
            position + new Vector3(Random.Range(-maxOffset, maxOffset), default, Random.Range(-maxOffset, maxOffset));

        public static Quaternion RandomizeVerticalRotation(this Quaternion rotation, float maxAngleOffset) =>
            rotation * Quaternion.Euler(default, Random.Range(-maxAngleOffset, maxAngleOffset), default);

        public static T RandomItem<T>(this IReadOnlyCollection<T> source)
        {
            source.ThrowExceptionIfArgumentIsNull(nameof(source)).ThrowExceptionIfNoElements();
            return source.ElementAt(source.RandomIndex());
        }

        public static int RandomIndex<T>(this IReadOnlyCollection<T> source)
        {
            source.ThrowExceptionIfArgumentIsNull(nameof(source)).ThrowExceptionIfNoElements();
            return Random.Range(default, source.Count);
        }

        public static List<T> PickRandomItems<T>(this IReadOnlyList<T> source, int countToPick)
        {
            source.ThrowExceptionIfArgumentIsNull(nameof(source)).ThrowExceptionIfNoElements();
            countToPick.ThrowExceptionIfArgumentOutOfRange(nameof(countToPick), default, countToPick);

            var pickedItems = new List<T>(source);
            int remainingItemsCount = source.Count - countToPick;
            for (var i = 0; i < remainingItemsCount; i++)
                pickedItems.RemoveAt(pickedItems.RandomIndex());
            return pickedItems;
        }
    }
}