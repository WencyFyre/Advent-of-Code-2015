using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day19 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day19\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            var molekul = input[^1];
            var molekuls = new List<string>();
            foreach (var line in input)
            {
                var inst = line.Split(" => ");
                if (inst.Length != 2) break;
                molekuls.AddRange(GetAllPossibleStrings(molekul, inst[0], inst[1]));
            }
            Console.WriteLine("Day19 Part One: "+ molekuls.Distinct().Count());

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var molekul = input[^1];
            List<string[]> parsedInput = new();
            foreach (var line in input)
            {
                var inst = line.Split(" => ");
                if (inst.Length != 2) break;
                parsedInput.Add(inst);
            }
            int c = 0;
            //ennek nem kéne működnie, de jó az output¯\_(ツ)_/¯
            //gondolom mert a generálás is hasonló és ez fordítva 
            while (molekul!="e")
            {
                Console.WriteLine(c);
                for (int i = 0; i < parsedInput.Count; i++)
                {
                    if (molekul.Contains(parsedInput[i][1]))
                    {
                        Regex regex = new(parsedInput[i][1]);
                        molekul = regex.Replace(molekul, parsedInput[i][0], 1);
                        c++;
                    }

                }
            }
            Console.WriteLine("Day19 Part Two: "+ c);
            
        }

        public static IEnumerable<string> GetAllPossibleStrings(string theString,string from, string toReplace)
        {
            var Match = new MatchEvaluator((m) => toReplace);
            Regex reg = new(from);
            for (int i = 0; i < theString.Length-from.Length+1; i++)
            {
                var str = reg.Replace(theString, Match, 1, i);
                if (str != theString) yield return str;
                else break;
            }
        }
    }
}
