using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day17 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day17\\input.txt");
        public void PartOne()
        {
            var input = Array.ConvertAll(File.ReadAllLines(path), s => int.Parse(s));
            var sums = FastPowerSet<int>(input).ToArray().Distinct().Where(x => x.Sum() == 150);
            Console.WriteLine("Day1 Part One: " + (sums.Count()).ToString());

        }

        public void PartTwo()
        {

            var input = Array.ConvertAll(File.ReadAllLines(path), s => int.Parse(s));
            var sums = FastPowerSet<int>(input).ToArray().Distinct().Where(x => x.Sum()==150);
            var shortest = int.MaxValue;
            foreach (var seq in sums)
            {
                if (seq.Length < shortest) shortest = seq.Length;
            }
            Console.WriteLine("Day1 Part One: " + (sums.Where(x=>x.Length==shortest).Count()));
        }

        public static T[][] FastPowerSet<T>(T[] seq)
        {
            var powerSet = new T[1 << seq.Length][];
            powerSet[0] = new T[0]; // starting only with empty set

            for (int i = 0; i < seq.Length; i++)
            {
                var cur = seq[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var source = powerSet[j];
                    var destination = powerSet[count + j] = new T[source.Length + 1];
                    for (int q = 0; q < source.Length; q++)
                        destination[q] = source[q];
                    destination[source.Length] = cur;
                }
            }
            return powerSet;
        }

    }
}
