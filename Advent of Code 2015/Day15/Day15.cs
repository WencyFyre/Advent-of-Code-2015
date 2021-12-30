using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day15 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day15\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            var ingrediends = new List<Ingredient>();
            foreach (var line in input)
            {
                var inst = Regex.Split(line,@",?:? ");
                ingrediends.Add(new Ingredient(inst[0], 
                    int.Parse(inst[2]),
                    int.Parse(inst[4]),
                    int.Parse(inst[6]),
                    int.Parse(inst[8]),
                    int.Parse(inst[10])));
            }
            var nums = AllAdditonForFourIng();
            int max = 0;
            foreach (var item in nums)
            {
                var current = CalculateScore(item, ingrediends);
                if (current > max) max = current;
            }

            

            Console.WriteLine("Day15 Part One: " + max);

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var ingrediends = new List<Ingredient>();
            foreach (var line in input)
            {
                var inst = Regex.Split(line, @",?:? ");
                ingrediends.Add(new Ingredient(inst[0],
                    int.Parse(inst[2]),
                    int.Parse(inst[4]),
                    int.Parse(inst[6]),
                    int.Parse(inst[8]),
                    int.Parse(inst[10])));
            }
            var nums = AllAdditonForFourIng();
            int max = 0;
            foreach (var item in nums)
            {
                var current = CalculateScoreWith500Cal(item, ingrediends);
                if (current > max) max = current;
            }
            Console.WriteLine("Day15 Part Two: "+ max);
        }

        public static List<List<int>> AllAdditonForFourIng()
        {
            List<List<int>> toReturn = new();
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    for (int k = 0; k < 101; k++)
                    {
                        for (int l = 0; l < 101; l++)
                        {
                            List<int> toAdd = new();
                            toAdd.Add(i);
                            toAdd.Add(j);
                            toAdd.Add(k);
                            toAdd.Add(l);
                            if (i + j + k + l == 100)
                            {
                                //Console.WriteLine($"{i} {j} {k} {l}");
                                toReturn.Add(toAdd);
                            }

                        }
                    }
                }
            }
            return toReturn;
        }

        public static int CalculateScore(List<int> numbers, List<Ingredient> ings)
        {
            int capsum = 0;
            int dursum = 0;
            int flavsum = 0;
            int textsum = 0;
            for (int i = 0; i < ings.Count; i++)
            {
                capsum += ings[i].Capacity * numbers[i];
                dursum += ings[i].Durability * numbers[i];
                flavsum += ings[i].Flavor * numbers[i];
                textsum += ings[i].Texture * numbers[i];
            }
            if (capsum <= 0 || dursum <= 0 || textsum <= 0 || flavsum <= 0) return 0;
            //Console.WriteLine(capsum + " " + dursum + " " + flavsum + " " + textsum);
            return capsum * dursum * textsum * flavsum;
        }

        public static int CalculateScoreWith500Cal(List<int> numbers, List<Ingredient> ings)
        {
            int capsum = 0;
            int dursum = 0;
            int flavsum = 0;
            int textsum = 0;
            int calorsum = 0;
            for (int i = 0; i < ings.Count; i++)
            {
                capsum += ings[i].Capacity * numbers[i];
                dursum += ings[i].Durability * numbers[i];
                flavsum += ings[i].Flavor * numbers[i];
                calorsum += ings[i].Calories * numbers[i];
                textsum += ings[i].Texture * numbers[i];
            }
            if (capsum <= 0 || dursum <= 0 || textsum <= 0 || flavsum <= 0 || calorsum!=500) return 0;
            //Console.WriteLine(capsum + " " + dursum + " " + flavsum + " " + textsum);
            return capsum * dursum * textsum * flavsum;
        }
    }
}
