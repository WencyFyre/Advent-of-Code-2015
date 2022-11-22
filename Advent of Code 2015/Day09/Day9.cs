using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day9 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day9\\input.txt");
        List<String> cities = new List<string>();
        Dictionary<(String, String), int> costs = new Dictionary<(string, string), int>();
        public void PartOne()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                var instructions = line.Split(' ');
                if (!cities.Contains(instructions[0])) cities.Add(instructions[0]);
                if (!cities.Contains(instructions[2])) cities.Add(instructions[2]);
                costs.Add((instructions[0], instructions[2]), int.Parse(instructions[4]));
                costs.Add((instructions[2], instructions[0]), int.Parse(instructions[4]));
            }
            int min = int.MaxValue;
            foreach (var permu in Permutate(cities, cities.Count))
            {
                int cost = CountCost(permu);
                if (min > cost) min = cost;
                //Console.WriteLine($"Költség: {cost}");
                
            }
            Console.WriteLine($"Day 9 Part 1: {min}");

        }

        private int CountCost(IList<string> permu)
        {
            int counter = 0;
            for (int i = 1; i < permu.Count; i++)
            {
                costs.TryGetValue((permu[i - 1], permu[i]), out int val);
                counter += val;
            }
            return counter;
        }


        public void PartTwo()
        {

            
            int max = int.MinValue;
            foreach (var permu in Permutate(cities, cities.Count))
            {
                int cost = CountCost(permu);
                if (max < cost) max = cost;
                //Console.WriteLine($"Költség: {cost}");

            }
            Console.WriteLine($"Day 9 Part 2: {max}");

        }


        public static void RotateRight<T>(IList<T> sequence, int count)
        {
            T tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList<T>> Permutate<T>(IList<T> sequence, int count)
        {
            if (count == 1) yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
    }
}
