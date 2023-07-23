using System;
using System.Collections.Generic;
using System.Linq;
using AutonomousParking.Common.Extensions;

namespace AutonomousParking.Common.Enumerations
{
    public class Tag
    {
        public static readonly Tag Wall = new(nameof(Wall));
        public static readonly Tag Car = new(nameof(Car));


        private static readonly Dictionary<string, Tag> tags =
            EnumExtensions.GetEnumeration<Tag>().ToDictionary(tag => tag.name);

        private readonly string name;
        private Tag(string name) => this.name = name;

        public static IReadOnlyList<Tag> List { get; } = tags.Values.ToList().AsReadOnly();

        public override string ToString() => name;

        public static implicit operator Tag(string tag)
        {
            if (!tags.ContainsKey(tag))
                throw new InvalidOperationException($"Tag {tag} is not exist. Define it in {nameof(Tag)} class.");
            return tags[tag];
        }
    }
}