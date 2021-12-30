using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Spell
    {
        public Spell(string name, int manaCost, int turn, Action<PlayerWithMana, Boss> effect)
        {
            Name = name;
            ManaCost = manaCost;
            Turn = turn;
            ApplyEffect = effect;
        }

        public string Name { get; private set; } = string.Empty;
        public int ManaCost { get; set; }
        public int Turn { get; set; }
        public Action<PlayerWithMana,Boss> ApplyEffect { get; private set; }
        public static IEnumerable<Spell> MakeMySpells()
        {
            yield return new Spell("Magic Missile", 53, -1, (player, boss) =>
            {
                boss.HP -= 4;
                Console.WriteLine($"Boss damgaged by Magic missile for 4 dmg");
            });
            yield return new Spell("Drain", 73, -1,(player, boss) =>
            {
                boss.HP -= 2;
                player.HP += 2;
                Console.WriteLine($"Boss Drained for 2 dmg and healed for 2 dmg");


            });
            yield return new Spell("Shield", 113, 6, (player, boss) =>
            {
                Console.WriteLine($"Shield is applied");

                player.Armor = 7;
            });
            yield return new Spell("Poison", 173, 6, (player, boss) =>
            {
                Console.WriteLine($"Boss poisoned for: 3");
                boss.HP -= 3;
            });
            yield return new Spell("Recharge", 229, 5, (player, boss) =>
            {
                Console.WriteLine($"Player gained 101 mana: from {player.Mana} to {player.Mana+101}");
                player.Mana += 101;

            });

        }

        internal static Spell GetASpell(int v)
        {
            return v switch
            {
                0 => new Spell("Magic Missile", 53, -1, (player, boss) =>
                                      {
                                          boss.HP -= 4;
                                         // Console.WriteLine($"Boss damgaged by Magic missile for 4 dmg");
                                      }),
                1 => new Spell("Drain", 73, -1, (player, boss) =>
               {
                   boss.HP -= 2;
                   player.HP += 2;
                   //Console.WriteLine($"Boss Drained for 2 dmg and healed for 2 dmg");


               }),
                2 => new Spell("Shield", 113, 6, (player, boss) =>
               {
                   //Console.WriteLine($"Shield is applied");

                   player.Armor = 7;
               }),
                3 => new Spell("Poison", 173, 6, (player, boss) =>
               {
                   //Console.WriteLine($"Boss poisoned for: 3");
                   boss.HP -= 3;
               }),
                4 => new Spell("Recharge", 229, 5, (player, boss) =>
               {
                   //Console.WriteLine($"Player gained 101 mana: from {player.Mana} to {player.Mana + 101}");
                   player.Mana += 101;

               }),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        internal static Spell GetSpellByName(string v)
        {
            return v switch
            {
                "Magic Missile" => new Spell("Magic Missile", 53, -1, (player, boss) =>
                {
                    boss.HP -= 4;
                    Console.WriteLine($"Boss damgaged by Magic missile for 4 dmg");
                }),
                "Drain" => new Spell("Drain", 73, -1, (player, boss) =>
                {
                    boss.HP -= 2;
                    player.HP += 2;
                    Console.WriteLine($"Boss Drained for 2 dmg and healed for 2 dmg");


                }),
                "Shield" => new Spell("Shield", 113, 6, (player, boss) =>
                {
                    Console.WriteLine($"Shield is applied");

                    player.Armor = 7;
                }),
                "Poison" => new Spell("Poison", 173, 6, (player, boss) =>
                {
                    Console.WriteLine($"Boss poisoned for: 3");
                    boss.HP -= 3;
                }),
                "Recharge" => new Spell("Recharge", 229, 5, (player, boss) =>
                {
                    Console.WriteLine($"Player gained 101 mana: from {player.Mana} to {player.Mana + 101}");
                    player.Mana += 101;

                }),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
