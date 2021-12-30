using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day22 : IDaySolution
    {
        readonly string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day22\\input.txt");
        public void PartOne()
        {
            var input = File.ReadAllText(path);
            var inst = input.Split(new char[] { '\n', ' ' });
            //boss létrehozása az input alapján
            var boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), 0);
            //játékos létrehozása a feladat alapján
            var player = new PlayerWithMana(50, 500);
            //minumum keresés programozási tétel
            int min = int.MaxValue;
            //bruteforce with randomness, Its kinda bueautiful
            for (int i = 0; i < 300000; i++)
            {
                //ha a játékos nyert akkor
                //Console.WriteLine(i);
                if (IsPlayerWinner(boss, player, false, out int answer, out var list))
                {
                    if (answer < min)//ellenőrzöm hogy kisebb-e az elköltött mana költség
                    {
                        min = answer;
                    }
                }
                //resetelem a bosst és a playert
                player = new PlayerWithMana(50, 500);
                boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), 0);

            }
            Console.WriteLine("Day22 Part One: " + min);

        }

        public void PartTwo()
        {
            var input = File.ReadAllText(path);
            var inst = input.Split(new char[] { '\n', ' ' });
            //boss létrehozása az input alapján
            var boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), 0);
            //játékos létrehozása a feladat alapján
            var player = new PlayerWithMana(50, 500);
            //minumum keresés programozási tétel
            int min = int.MaxValue;
            //próbálkozás 300000-szer
            for (int i = 0; i < 300000; i++)
            {
                //ha a játékos nyert akkor
                //Console.WriteLine(i);
                if (IsPlayerWinner(boss, player, true, out int answer, out var list))
                {
                    if (answer < min)//ellenőrzöm hogy kisebb-e az elköltött mana költség
                    {
                        min = answer;

                        //Console.Out.WriteLine(answer);
                        //SimulateBattle(boss,player,list);
                    }
                }
                //resetelem a bosst és a playert
                player = new PlayerWithMana(50, 500);
                boss = new Boss(int.Parse(inst[2]), int.Parse(inst[4]), 0);

            }
            Console.WriteLine("Day22 Part One: " + min);
        }

        public static bool IsPlayerWinner(Boss boss, PlayerWithMana player, bool part2, out int answer,out List<Spell> selectedSplelltoReturn)
        {     
            bool isPlayersTurn = true;
            var ActiveEffects = new List<Spell>();
            Random random = new();
            var count = 0;
            var castedSpeel = new List<Spell>();
            var selectedSplell = Spell.GetASpell(random.Next(0, 5));
            
            do
            {
                if (part2 && isPlayersTurn)
                {
                    player.HP -= 1;
                    if (player.HP <= 0) break;
                }
                //épp aktív effekteket triggerelem, majd a körükből leveszek 1-et
                ActiveEffects.ForEach(effect =>
                {
                    effect.ApplyEffect(player, boss);
                    effect.Turn -= 1;
                });

                //kiszedem a listából azokat, amik lejártak
                ActiveEffects = ActiveEffects.Where(x => x.Turn > 0).ToList();

                //generálok egy spellet amit épp nem egy aktív effect
                do
                {
                    selectedSplell = Spell.GetASpell(random.Next(0, 5));
                } while (ActiveEffects.Where(x => x.Name == selectedSplell.Name).Any()); 

                //ellenőrzöm hogy ki következik
                if (isPlayersTurn)
                {
                    //ha instant a spell ide lép be
                    if (selectedSplell.Turn == -1)
                    {
                        selectedSplell.ApplyEffect(player, boss); //triggerelem az instant effectet
                        castedSpeel.Add(selectedSplell);
                        player.Mana -= selectedSplell.ManaCost;
                        //Console.WriteLine(boss.HP);
                        count += selectedSplell.ManaCost;       //a manaköltséget hozzáadom a számlálóhoz
                    }
                    //ha effektet rakok fel
                    else
                    {
                        //Console.WriteLine("You are cursed monster!");
                        ActiveEffects.Add(selectedSplell); //hozzádok az aktív effektek listájába
                        castedSpeel.Add(selectedSplell);
                        player.Mana -= selectedSplell.ManaCost;
                        count += selectedSplell.ManaCost; //hozzáadom az aktív effektekhez
                    }
                    isPlayersTurn = !isPlayersTurn; //a boss jön
                }
                //ha a bos van
                else
                {
                    //a az effektekbe belehalt akkor kilépek a ciklusból
                    //Console.WriteLine(boss.HP);
                    if (boss.HP < 1) break;
                    player.HP -= (boss.Damage - player.Armor < 1 ? 1 : boss.Damage - player.Armor); //sebzem a játékost az armorja alapján
                    //Console.WriteLine($"BOSS IS RAGING FOR {(boss.Damage - player.Armor < 1 ? 1 : boss.Damage - player.Armor)}");
                    isPlayersTurn = !isPlayersTurn; //cserélem a játékost
                }
                player.Armor = 0; //ha effektként nőtt az armoraja akkor visszaállítom
                //Console.WriteLine($"Player: {player.HP}, {player.Armor}, {player.Mana}, Boss: {boss.HP}");
                //Console.WriteLine("###########################################################");

            } while (player.HP > 0 && boss.HP > 0 && player.Mana>0); //ha meghalt valaki vagy ha elfogyott a mana kilépek

            selectedSplelltoReturn = castedSpeel;
            answer = count; //visszadom a választ
            if (player.HP <= 0) return false;
            if (boss.HP > 0) return false;
            return player.HP>0 && player.Mana>=0; //visszadom hogy a játékos nyert-e
        }

        public static void SimulateBattle(Boss boss, PlayerWithMana player, List<Spell> spells)
        {
            bool isPlayersTurn = true;
            var ActiveEffects = new List<Spell>();
            var spellstocast = new List<Spell>();
            foreach (var selected in spells)
            {
                spellstocast.Add(Spell.GetSpellByName(selected.Name));
            }
            spells = spellstocast;
            Console.WriteLine(spells.Count + "<-spellek");
            do
            {
                //épp aktív effekteket triggerelem, majd a körükből leveszek 1-et
                ActiveEffects.ForEach(effect =>
                {
                    effect.ApplyEffect(player, boss);
                    effect.Turn -= 1;
                });

                //kiszedem a listából azokat, amik lejártak
                ActiveEffects = ActiveEffects.Where(x => x.Turn > 0).ToList();

                //generálok egy spellet amit épp nem egy aktív effect
                        if (boss.HP < 1) break;     //ha ezzel a spellel meg is öltem akkor kilépek a ciklusból

                var selectedSplell = spells.First();
                spells.RemoveAt(0);

                //ellenőrzöm hogy ki következik
                if (isPlayersTurn)
                {
                    //ha instant a spell ide lép be
                    if (selectedSplell.Turn == -1)
                    {
                        player.Mana -= selectedSplell.ManaCost;
                        selectedSplell.ApplyEffect(player, boss); //triggerelem az instant effectet
                        if (boss.HP < 1) break;     //ha ezzel a spellel meg is öltem akkor kilépek a ciklusból
                    }
                    //ha effektet rakok fel
                    else
                    {
                        player.Mana -= selectedSplell.ManaCost;
                        Console.WriteLine("You are cursed monster!");
                        ActiveEffects.Add(selectedSplell); //hozzádok az aktív effektek listájába
                    }
                    isPlayersTurn = !isPlayersTurn; //a boss jön
                }
                //ha a bos van
                else
                {
                    //a az effektekbe belehalt akkor kilépek a ciklusból
                    if (boss.HP < 1) break;
                    player.HP -= (boss.Damage - player.Armor < 1 ? 1 : boss.Damage - player.Armor); //sebzem a játékost az armorja alapján
                    Console.WriteLine($"BOSS IS RAGING FOR {(boss.Damage - player.Armor < 1 ? 1 : boss.Damage - player.Armor)}");
                    isPlayersTurn = !isPlayersTurn; //cserélem a játékost
                }
                player.Armor = 0; //ha effektként nőtt az armoraja akkor visszaállítom
                Console.WriteLine($"Player: {player.HP}, {player.Armor}, Boss: {boss.HP}");
                Console.WriteLine("###########################################################");

            } while (!(player.HP <= 0 || boss.HP <= 0 || player.Mana <= 0)); //ha meghalt valaki vagy ha elfogyott a mana kilépek

        }


    }
}
