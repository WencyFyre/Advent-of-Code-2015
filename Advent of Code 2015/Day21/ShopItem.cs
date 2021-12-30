using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class ShopItem : IShopItem
    {
        public string Name { get; private set; } = String.Empty;
        public int Cost { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public int Max { get => 1; }
        public int Min { get => 1; }

        public ShopItem(string name, int cost, int damagae, int armor)
        {
            Name = name;
            Cost = cost;
            Damage = damagae;
            Armor = armor;
        }


    }
}
