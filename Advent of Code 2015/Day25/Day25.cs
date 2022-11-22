using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day25
        : IDaySolution
    {
        readonly string path = Path.Combine(@"C:\Users\wency\Source\Repos\Advent-of-Code-2015\Advent of Code 2015\Day25\input.txt");
        const long multiply = 252533;
        const long modby = 33554393;
        public void PartOne()
        {
            var input = Regex.Matches(File.ReadAllLines(path)[0], @"\d+").ToArray();
            long currentcode = 20151125;
            int row = input[0].Value.ParseToInt();
            int column = input[1].Value.ParseToInt();
            Console.WriteLine(row + " " + column);
            int currentRow = 1;
            int currentColumn = 1;
            do
            {
                currentColumn++;
                currentRow--;
                currentcode = GenerateNextCode(currentcode);
                if (currentRow == 0)
                {
                    currentRow = currentColumn;
                    currentColumn = 1;
                }
                //Console.WriteLine(currentcode);
            }
            while (currentRow != row || currentColumn != column);
            Console.WriteLine("Day1 Part One: " + currentcode);

        }

        public void PartTwo()
        {
            
            Console.WriteLine("Day1 Part Two: " + ":)");
        }

        private long GenerateNextCode(long code)
        {
            return code*multiply%modby;
        }
    }
}
