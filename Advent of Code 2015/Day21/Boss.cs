using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Boss
    {
        public Boss(int hP, int damage, int armor)
        {
            HP = hP;
            Damage = damage;
            Armor = armor;
        }

        public int HP { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }

        

        
        
    }
}
