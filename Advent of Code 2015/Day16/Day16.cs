using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day16 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day16\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            var sue = MakeMeSue();
            string winner = "";
            foreach (var line in input)
            {
                var inst = Regex.Split(line, "S?u?e?:?,? ");
                //Console.WriteLine(inst[1] + inst.Length);
                if( sue.TryGetValue(inst[2],out int val))
                {
                   // Console.WriteLine("first");
                    if(val == int.Parse(inst[3]) && sue.TryGetValue(inst[4],out int val2))
                    {
                        //Console.WriteLine("second");

                        if (val2 == int.Parse(inst[5]) && sue.TryGetValue(inst[6], out int val3))
                        {
                            //Console.WriteLine("third");

                            if (val3 == int.Parse(inst[7]))
                            {
                                winner = inst[1];
                            }
                        }
                    }
                }
                
            }
            Console.WriteLine("Day1 Part One: " + winner);

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var sue = MakeMeSue();
            string winner = "";
            foreach (var line in input)
            {
                var inst = Regex.Split(line, "S?u?e?:?,? ");
                //Console.WriteLine(inst[1] + inst.Length);
                if (IsItMySue(inst, 2, sue))
                {
                    winner=inst[1];
                    break;
                }

            }
            Console.WriteLine("Day1 Part Two: " + winner);
        }

        public static Dictionary<string,int> MakeMeSue()
        {
            var Sue = new Dictionary<string, int>
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 }
            };
            return Sue;
        }

        public static bool IsItMySue(string[] inst, int index, Dictionary<string, int> sue)
        {
            if (index+1 >= inst.Length) return true;
            if (sue.TryGetValue(inst[index], out int val))
            {
                if (inst[index] == "cats" || inst[index] == "trees")
                {
                    if(val < int.Parse(inst[index+1])) return IsItMySue(inst, index+2, sue);
                }
                else if (inst[index] == "pomeranians" || inst[index] == "goldfish")
                {
                    if (val > int.Parse(inst[index + 1])) return IsItMySue(inst, index + 2, sue);
                }
                else
                {
                    if (val == int.Parse(inst[index + 1])) return IsItMySue(inst, index + 2, sue);
                }
            }
            return false;
        }
    }
}
