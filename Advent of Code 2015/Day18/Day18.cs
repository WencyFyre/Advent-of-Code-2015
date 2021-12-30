using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day18 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day18\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            var light = new Lights(input);
            light.PrintState();
            for (int i = 0; i < 100; i++) {
                light.CalcNextState();
            } 

            light.PrintState();
            Console.WriteLine("Day1 Part One: " + light.CountLightsInGrid());

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var light = new Lights(input);
            light.PrintState();
            light.SwitchOnCorners();
            for (int i = 0; i < 100; i++)
            {
                light.CalcNextState();
                light.SwitchOnCorners();
            }

            light.PrintState();
            Console.WriteLine("Day1 Part Two: " + light.CountLightsInGrid());
        }
    }
}
