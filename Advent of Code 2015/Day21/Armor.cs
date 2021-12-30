using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Armor : ShopItem, IShopItem
    {
        public new static int Max { get => 1; }
        public new static int Min { get => 0; }

        public Armor(string name, int cost, int damagae, int armor) : base(name, cost, damagae, armor)
        {
        }
        public static IEnumerable<ShopItem> MakeMeArmors()
        {
            yield return new Armor("Leather", 13, 0, 1);
            yield return new Armor("Chainmail", 31, 0, 2);
            yield return new Armor("Splintmail", 53, 0, 3);
            yield return new Armor("Bandedmail", 75, 0, 4);
            yield return new Armor("Platemail", 102, 0, 5);
        }
    }
}
