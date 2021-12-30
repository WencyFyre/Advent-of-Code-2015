using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Weapon : ShopItem, IShopItem
    {
        public new int Max { get => 1; }
        public new int Min { get => 1; }

        public Weapon(string name, int cost, int damagae, int armor) : base(name, cost, damagae, armor)
        {
        }
        public static IEnumerable<ShopItem> MakeMeWeapons()
        {
            yield return new Weapon("Dagger", 8, 4, 0);
            yield return new Weapon("Shortsword", 10, 5, 0);
            yield return new Weapon("Warhammer", 25, 6, 0);
            yield return new Weapon("Longsword", 40, 7, 0);
            yield return new Weapon("Greataxe", 74, 8, 0);
        }
    }
}
