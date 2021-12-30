using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day23
        : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day23\\input.txt");
        public void PartOne()
        {
            var input = File.ReadAllLines(path);
            uint a = 0;
            uint b = 0;
            int i = 0;
            //Console.WriteLine($"-1: {"-1".ParseToInt()}, +1: {"+1".ParseToInt()})");
            while( i<input.Length && i>-1)
            {
                var inst = input[i].Split(new char[] { ',', ' ' });
                //Console.WriteLine($"{i}, a: {a}, b:{b}");
                switch (inst[0])
                {
                    case "hlf":
                        if(inst[1] == "a")
                            a /= 2;
                        else
                            b /= 2;
                        i++;
                        break;
                    case "tpl":
                        if (inst[1] == "a")
                            a *= 3;
                        else
                            b *=3;
                        i++;
                        break;
                    case "inc":
                        if (inst[1] == "a")
                            a++;
                        else
                            b++;
                        i++;
                        break;
                    case "jmp":
                        i+=inst[1].ParseToInt();
                        break;
                    case "jie":
                        if (inst[1] == "a")
                        {
                            if (a.IsEven()) 
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        else 
                        { 
                            if (b.IsEven()) 
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        break;
                    case "jio":
                        if (inst[1] == "a")
                        {
                            if (a == 1) 
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        else
                        {
                            if (b == 1) 
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        break;
                    default:
                        throw new Exception("Invalid Instructions");
                }
            }

            Console.WriteLine("Day1 Part One: "+ b);

        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(path);
            uint a = 1;
            uint b = 0;
            int i = 0;
            //Console.WriteLine($"-1: {"-1".ParseToInt()}, +1: {"+1".ParseToInt()})");
            while (i < input.Length && i > -1)
            {
                var inst = input[i].Split(new char[] { ',', ' ' });
                //Console.WriteLine($"{i}, a: {a}, b:{b}");
                switch (inst[0])
                {
                    case "hlf":
                        if (inst[1] == "a")
                            a /= 2;
                        else
                            b /= 2;
                        i++;
                        break;
                    case "tpl":
                        if (inst[1] == "a")
                            a *= 3;
                        else
                            b *= 3;
                        i++;
                        break;
                    case "inc":
                        if (inst[1] == "a")
                            a++;
                        else
                            b++;
                        i++;
                        break;
                    case "jmp":
                        i += inst[1].ParseToInt();
                        break;
                    case "jie":
                        if (inst[1] == "a")
                        {
                            if (a.IsEven())
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        else
                        {
                            if (b.IsEven())
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        break;
                    case "jio":
                        if (inst[1] == "a")
                        {
                            if (a == 1)
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        else
                        {
                            if (b == 1)
                                i += (inst[3].ParseToInt());
                            else
                                i++;
                        }
                        break;
                    default:
                        throw new Exception("Invalid Instructions");
                }
            }
            Console.WriteLine("Day23 Part Two: "+b);
        }
    }
}
