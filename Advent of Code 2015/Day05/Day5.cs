using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day5 : IDaySolution

    {

        char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        string[] invalidPairs = new string[] { "ab", "cd", "pq", "xy" };
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day5\\input.txt");
        public void PartOne()
        {
            int counter = 0;
            string[] input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                if (IsNiceString(line)) counter++;
            }
            Console.WriteLine("Day5 Part One: " + counter.ToString());


        }

        public void PartTwo()
        {
            int counter = 0;
            string[] input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                if (IsNiceString2(line)) counter++;
            }
            Console.WriteLine("Day5 Part Two: " + counter.ToString());
        }

        bool IsNiceString(String line)
        {
            int counter = 0;
            foreach(char ch in line)
            {
                if (vowels.Contains(ch)) counter++;
            }
            if (counter < 3) return false;
            bool doubl = false;
            for (int i = 1; i < line.Length; i++)
            {
                if (line[i] == line[i - 1]) doubl = true;
                continue;
            }
            if (!doubl) return false;
            for (int i = 1; i < line.Length; i++)
            {
                if (invalidPairs.Contains(String.Concat(line[i - 1], line[i]))) return false;
            }
            return true;
        }
public static bool IsNiceString2(String line)
{
    bool hasCharBetween = false;
    for (int i = 2; i < line.Length; i++)
    {
        if (line[i - 2] == line[i]) hasCharBetween = true;
    }
    if (!hasCharBetween) return false;
    for (int i = 1; i < line.Length; i++)
    {
        for (int j = i; j < line.Length-2; j++)
        {
            if (line[i - 1] == line[j + 1] && line[i] == line[j + 2]) return true; //drew it on paper, it works, really
        }
    }
    return false;
        }
    }
}
