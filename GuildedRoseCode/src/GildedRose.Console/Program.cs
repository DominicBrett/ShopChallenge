using System;
using System.Collections.Generic;
using MarkdownLog;

namespace GildedRose.Application
{
    public static class Program
    {
        public static IList<Item> Items;

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            Shop.Items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20, IsBackStagePass = false, IsCheese = false, IsLegendary = false, IsConjured = false},
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0, IsBackStagePass = false, IsCheese = true, IsLegendary = false, IsConjured = false},
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7, IsBackStagePass = false, IsCheese = false, IsLegendary = false },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80, IsBackStagePass = false, IsCheese = false, IsLegendary = true, IsConjured = false},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20, IsBackStagePass = true, IsCheese = false, IsLegendary = false, IsConjured = false},
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 60, IsBackStagePass = false, IsCheese = false, IsLegendary = false, IsConjured = true}
            };

            while (true)
            {
                Console.Clear();

                Shop.UpdateShopItems();

                Console.WriteLine(Shop.Items.ToMarkdownTable());

                Console.ReadKey();
            }
        }
    }
}