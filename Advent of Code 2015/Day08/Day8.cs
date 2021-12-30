using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day8 : IDaySolution

    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day8\\input.txt");


        public void PartOne()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            int charsum = 0;
            int memory = 0;
            foreach (var line in input)
            {
                charsum += line.Length;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\')
                    {
                        i++;
                        if (line[i]=='x') i+=2;
                    }
                    memory++;
                }
                memory -= 2;
            }
            Console.WriteLine("Day8 Part One: " + (charsum - memory));
        }



        public void PartTwo()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            int charsum = 0;
            int memory = 0;
            for (int index = 0; index < input.Length; index++)
            {
                var line = input[index];
                StringBuilder newLine = new StringBuilder();
                newLine.Append('\"');
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\' || line[i] == '\"')
                    {
                        newLine.Append('\\');
                    }
                    newLine.Append(line[i]);

                }
                newLine.Append('\"');
                input[index] = newLine.ToString();
                //Console.WriteLine(input[index]);

            }
            foreach (var line in input)
            {
                charsum += line.Length;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '\\')
                    {
                        i++;
                        if (line[i] == 'x') i += 2;
                    }
                    memory++;
                }
                memory -= 2;
            }
            Console.WriteLine("Day8 Part Two: " + (charsum - memory));
        }
    }
}
