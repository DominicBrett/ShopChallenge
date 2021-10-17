using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GildedRose.Application
{
    public static class Shop
    {
        public const int MAX_QUALITY = 50;
        public const int MIN_QUALITY = 0;
        public const int BASE_DEGRADATION_RATE = 1;

        public static IList<Item> Items;

        public static void UpdateShopItems()
        {
            //Iterates through Items and updates the SellIn and Quality of each one
            foreach (var item in Items)
            {
                UpdateItemSellIn(item);
                var degradationRate = CalculateDegradation(item);
                var appreciationRate = CalculateAppreciation(item);
                UpdateItemQuality(item, degradationRate, appreciationRate);
            }
        }

        private static void UpdateItemSellIn(Item item)
        {
            if (!item.IsLegendary)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
        //Calculates how much an item should degrade using the item's attributes
        private static int CalculateDegradation(Item item)
        {
            var degradationRate = BASE_DEGRADATION_RATE;
            if (item.IsLegendary || item.IsCheese)
            {
                return 0;
            }
            if (item.IsBackStagePass)
            {
                return CalculateBackStagePassDegradation(item);
            }
            if (item.IsConjured)
            {
                degradationRate = degradationRate * 2;
            }
            if (item.SellIn < MIN_QUALITY)
            {
                degradationRate = degradationRate * 2;
            }
            return degradationRate;
        }

        private static int CalculateBackStagePassDegradation(Item item)
        {
            if (item.SellIn < MIN_QUALITY)
            {
                return item.Quality;
            }
            else
            {
                return 0;
            }
        }
        private static int CalculateAppreciation(Item item)
        {
            if (item.IsBackStagePass)
            {
                return CalculateBackStagePassAppreciation(item);
            }
            if (item.IsCheese)
            {
                if (item.SellIn < MIN_QUALITY)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }
        private static int CalculateBackStagePassAppreciation(Item item)
        {
            if (item.Quality >= MAX_QUALITY || item.Quality <= MIN_QUALITY)
            {
                return 0;
            }
            else if (item.SellIn < 6)
            {
                return BASE_DEGRADATION_RATE * 3;
            }
            else if (item.SellIn < 11)
            {
                return BASE_DEGRADATION_RATE * 2;
            }
            else
            {
                return BASE_DEGRADATION_RATE * 1;
            }

        }
        private static void UpdateItemQuality(Item item, int degradationRate, int appreciationRate)
        {
            item.Quality = item.Quality - degradationRate;
            item.Quality = item.Quality + appreciationRate;
            if (item.Quality < MIN_QUALITY)
            {
                item.Quality = MIN_QUALITY;
            }

            if (item.Quality > MAX_QUALITY && !item.IsLegendary)
            {
                item.Quality = MAX_QUALITY;
            }
        }
    }
}