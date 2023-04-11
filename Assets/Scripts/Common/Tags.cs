using System.Collections.Generic;
using System.Linq;

namespace AutomaticParking.Common
{
    public class Tags
    {
        public const string Wall = "Wall";
        public const string Car = "Car";

        public static IReadOnlyList<string> List { get; } = new List<string> { Wall, Car }.ToList().AsReadOnly();
    }
}