using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day10 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\Source\\Repos\\Advent-of-Code-2015\\Advent of Code 2015\\Day10\\input.txt");
        public void PartOne()
        {
            string input = System.IO.File.ReadAllText(path);
            for (int i = 0; i < 40; i++) //4 perc
            {
                string newInput = "";
                do
                {
                    var fsts = input.TakeWhile((ch) => ch == input[0]).ToArray();
                    newInput += fsts.Length + fsts[0].ToString();
                    input = new string(input.Skip(fsts.Length).ToArray());

                } while (input.Length != 0);
                Console.WriteLine((i + 1));
                input = newInput;


            }
            Console.WriteLine($"Day10 Part One: {input.Length}");


        }

        public void PartTwo()
        {
            char[] inputChar = System.IO.File.ReadAllText(path).ToArray();
            
            var input = new List<int>(Array.ConvertAll(inputChar, c => int.Parse(c.ToString())));
            for (int i = 0; i < 50; i++) // túl sokat kellett várni, így saját algoritmus ami már szamokkal dolgozik. futási idő  <1 sec
            {
                var newInput = new List<int>();

                for (int index = 1; index < input.Count; index++)
                {
                    int counter = 1;
                    while(input[index] == input[index - 1])
                    {
                        counter++;
                        index++;
                        if (index == input.Count)
                        {
                            break;
                        }
                    }
                    newInput.Add(counter);
                    newInput.Add(input[index-1]);
                    if (index == input.Count - 1)
                    {
                        newInput.Add(1);
                        newInput.Add(input[index]);
                    }
                    //Console.WriteLine(string.Join("", newInput)+ " " + index );
                }
                input = newInput;
                Console.WriteLine((i+1));


            }
            Console.WriteLine($"Day10 Part Two: {input.Count}");

        }
    }
}
