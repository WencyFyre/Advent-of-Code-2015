using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Ring : ShopItem, IShopItem
    {
        public new static int Max { get => 2; }
        public new static int Min { get => 0; }

        public Ring(string name, int cost, int damagae, int armor) : base(name, cost, damagae, armor)
        {
        }

        public static IEnumerable<ShopItem> MakeMeRings()
        {
            yield return new Ring("Damage +1", 25, 1, 0);
            yield return new Ring("Damage +2", 50, 2, 0);
            yield return new Ring("Damage +3", 100, 3, 0);
            yield return new Ring("Defense +1", 20, 0, 1);
            yield return new Ring("Defense +2", 40, 0, 2);
            yield return new Ring("Defense +3", 80, 0, 3);
        }
    }
}
