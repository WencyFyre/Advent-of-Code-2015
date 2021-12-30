using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day1 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day1\\input.txt");
        public void PartOne()
        {
            string input = System.IO.File.ReadAllText(path);
            int floor = 0;
            foreach (var character in input)
            {
                if (character == '(') floor++;
                else floor--;
            }
            Console.WriteLine("Day1 Part One: " + floor.ToString());

        }

        public void PartTwo()
        {
            string input = System.IO.File.ReadAllText(path);
            int floor = 0;
            int index = 1;
            foreach (var character in input)
            {
                if (character == '(') floor++;
                else floor--;
                if (floor == -1) break;
                index++;
            }
            Console.WriteLine("Day1 Part Two: " + index.ToString());
        }
    }
}
