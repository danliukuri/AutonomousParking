using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutomaticParking.Common.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetEnumeration<T>() => typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.FieldType == typeof(T))
            .Select(field => (T)field.GetValue(default));
    }
}