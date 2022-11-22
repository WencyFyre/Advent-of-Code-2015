using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Advent_of_Code_2015
{
    public class Day24 : IDaySolution
    {
        readonly string path = Path.Combine(@"C:\Users\wency\Source\Repos\Advent-of-Code-2015\Advent of Code 2015\Day24\input.txt");
        public void PartOne()
        {
            var input = File.ReadAllLines(path).Select(x => x.ParseToLong()).ToList();
            var SumUp = new SumUp(input, 3);
            var SumUps = SumUp.GetSumUps();
            var min = long.MaxValue;
            foreach (var item in SumUps)
            {
                var qe = item.ToArray().CalcQuantumEntanglement();
                if (qe < min && qe > 0) min = qe;
            }
            Console.WriteLine("Day24 Part One: " + min);

        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(path).Select(x => x.ParseToLong()).ToList();
            var SumUp = new SumUp(input, 4);
            var SumUps = SumUp.GetSumUps();
            var min = long.MaxValue;
            foreach (var item in SumUps)
            {
                var qe = item.ToArray().CalcQuantumEntanglement();
                if (qe < min && qe > 0) min = qe;
            }
            Console.WriteLine("Day24 Part Two: " + min);
        }

        
        public static long MinimumQuantumEntanglement(IOrderedEnumerable<long> one, IOrderedEnumerable<long> two, IOrderedEnumerable<long> three)
        {
            return Enumerable.Min(new[]
            {
                one.ToArray().CalcQuantumEntanglement(),
                two.ToArray().CalcQuantumEntanglement(),
                three.ToArray().CalcQuantumEntanglement()
            });
        }


 

    }
}
