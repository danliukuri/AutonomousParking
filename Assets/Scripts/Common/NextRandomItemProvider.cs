using System.Collections.Generic;
using AutomaticParking.Common.Extensions;

namespace AutomaticParking.Common
{
    public class NextRandomItemProvider<T>
    {
        private readonly IList<T> list;
        private int currentIndex;

        public NextRandomItemProvider(IList<T> list) => this.list = list;

        public T Get()
        {
            list.SwapItemWithNextRandom(currentIndex);
            T newRandomItem = list[currentIndex];
            currentIndex = currentIndex.NextInCycledRange(list);
            return newRandomItem;
        }
    }
}