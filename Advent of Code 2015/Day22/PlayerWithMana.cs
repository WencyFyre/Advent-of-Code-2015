using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class PlayerWithMana : Player
    {
        public int Mana { get; set; }
        public  PlayerWithMana(int hp, int mana) : base(hp)
        {
            Mana = mana; 
        }
    }
}
