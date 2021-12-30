using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Player
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Armor { get;  set; }
        public int SpentMondey { get;  set; }

        private readonly IList<IShopItem> Items;

        public Player(int hp)
        {
            HP = hp;
            Damage = 0;
            Armor = 0;
            SpentMondey = 0;
            Items= new List<IShopItem>();
        }

        public bool AddItem(IShopItem item)
        {
            Items.Add(item);
            Damage += item.Damage;
            Armor+=item.Armor;
            SpentMondey += item.Cost;
            return true;
        }

        internal void ResetItems()
        {
            Items.Clear();
            Armor = 0;
            Damage = 0;
            SpentMondey = 0;
        }

    }
}
