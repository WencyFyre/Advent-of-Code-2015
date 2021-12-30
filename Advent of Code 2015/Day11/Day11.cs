using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day11 : IDaySolution
    {
        char[] part1;
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day11\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllText(path).ToArray();
            
                do
                {
                   input = IncCharArray(input);
                //Console.WriteLine(new String(input));
                } while (!IsValidPassword(input));
            part1 = input;

            Console.WriteLine($"Day11 Part One: {new String(input)}");

        }

        public void PartTwo()
        {
            var input = part1;
            do
            {
                input = IncCharArray(input);
                //Console.WriteLine(new String(input));
            } while (!IsValidPassword(input));

            Console.WriteLine($"Day11 Part Two: {new String(input)}");


        }

        public static char[] IncCharArray(char[] str)
        {
            str[str.Length - 1]++;
            for (int i = str.Length-1; i > -1; i--)
            {
                if(str[i] >'z')
                {
                    if (i-1>-1) str[i-1]++;
                    str[i] = 'a';
                }
            }
            return str;
        }

        public static bool IsValidPassword(char[] str)
        {
            char[] banned = new char[] { 'i', 'o', 'l' };
            foreach (char ch in str)
            {
                if (banned.Contains(ch)) return false;
            }
            //Console.WriteLine("iol nincs benne");
            bool twodouble = false;
            for (int i = 2; i < str.Length; i++)
            {
                if ((str[i] == (str[i - 1] + 1) && str[i] == (str[i - 2] + 2)))
                {
                   
                    twodouble = true;
                    break;
                }
            }
            if (!twodouble) return false;
            //Console.WriteLine("van 3 egymás utáni");

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    for (int j = i+2; j < str.Length; j++)
                    {

                        if (str[j] == str[j - 1]) return true;
                       
                    }
                }
            }

            return false;
        }
    }
}
