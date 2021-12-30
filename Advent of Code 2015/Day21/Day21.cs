using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day21 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day21\\input.txt");
        public void PartOne()
        {
            var input = File.ReadAllText(path);
            var inst = input.Split(new char[] {'\n',' '});
            var boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), int.Parse(inst[6]));
            var player = new Player(100);
            var possibleWeapons = Weapon.MakeMeWeapons();
            var possibleRings = Day17.FastPowerSet(Ring.MakeMeRings().ToArray()).Where(x=>x.Length<=Ring.Max && x.Length>=Ring.Min).Distinct();
            var possibleArmor = Day17.FastPowerSet(Armor.MakeMeArmors().ToArray()).Where(x => x.Length <= Armor.Max && x.Length >= Armor.Min).Distinct();
            var min = int.MaxValue;            
            foreach (var wep in possibleWeapons)
                foreach (var ring in possibleRings)
                    foreach (var armo in possibleArmor)
                    {
                        var items = new List<ShopItem>();
                        items.Add(wep);
                        items.AddRange(ring);
                        items.AddRange(armo);
                        if (IsPlayerWinner(boss, player, items)) 
                        {
                            //Console.WriteLine(items.Sum(x=>x.Cost));
                            if (player.SpentMondey<min) min = player.SpentMondey;
                            //Console.WriteLine($")
                        }
                        player.ResetItems();

                    }
            Console.WriteLine("Day21 Part One: " + min);

        }

        public void PartTwo()
        {
            var input = File.ReadAllText(path);
            var inst = input.Split(new char[] { '\n', ' ' });
            var boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), int.Parse(inst[6]));
            var player = new Player(100);
            var possibleWeapons = Weapon.MakeMeWeapons();
            var possibleRings = Day17.FastPowerSet(Ring.MakeMeRings().ToArray()).Where(x => x.Length <= Ring.Max && x.Length >= Ring.Min).Distinct();
            var possibleArmor = Day17.FastPowerSet(Armor.MakeMeArmors().ToArray()).Where(x => x.Length <= Armor.Max && x.Length >= Armor.Min).Distinct();
            var max = int.MinValue;
            foreach (var wep in possibleWeapons)
                foreach (var ring in possibleRings)
                    foreach (var armo in possibleArmor)
                    {
                        var items = new List<ShopItem>();
                        items.Add(wep);
                        items.AddRange(ring);
                        items.AddRange(armo);
                        if (!IsPlayerWinner(boss, player, items))
                        {
                            Console.WriteLine(items.Sum(x => x.Cost) + " " + player.SpentMondey);
                            if (player.SpentMondey > max) max = player.SpentMondey;
                            //Console.WriteLine($")
                        }
                        player.ResetItems();

                    }
            Console.WriteLine("Day21 Part Two: " + max);
        }

        public static bool IsPlayerWinner(Boss boss, Player player, List<ShopItem> items)
        {
            var Bosshp = boss.HP;
            var Playerhp = player.HP;
            items.ForEach(x => player.AddItem(x));
            bool isPlayersTurn = true;
            //Console.WriteLine("boss hp" + boss.Damage);
            do
            {
                if (isPlayersTurn)
                {
                    var dmg = player.Damage - boss.Armor < 1 ? 1 : player.Damage - boss.Armor;
                    if (player.Damage == 0) dmg = 0;
                    Bosshp -= dmg;
                    isPlayersTurn = !isPlayersTurn;
                }
                else
                {
                    //a bossnak nincs 0 dmg-e sose
                    Playerhp -= (boss.Damage - player.Armor < 1 ? 1 : boss.Damage - player.Armor);
                    isPlayersTurn = !isPlayersTurn;
                }
                //Console.WriteLine($"Bosshp: {Bosshp}, PlayerHP: {Playerhp}");

            } while (!(Playerhp<=0 || Bosshp<=0));
            return Playerhp > 0;
        }

        
    }
}
