using System.Runtime.CompilerServices;

namespace GildedRose.Application
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public bool IsLegendary { get; set; }

        public bool IsBackStagePass { get; set; }

        public bool IsCheese { get; set; }

        public bool IsConjured { get; set; }
    }
}