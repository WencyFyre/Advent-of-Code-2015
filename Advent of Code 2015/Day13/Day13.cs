using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day13 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day13\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            var datas = new Dictionary<(string, string), int>(); //(ki, ki melett), mennyit nyer/veszít
            var members = new List<string>();
            foreach (var line in input) 
            {
                var instructions = line.Remove(line.Length-1).Split(' ');
                //Console.WriteLine(instructions.Length);
                if (!members.Contains(instructions[0])) members.Add(instructions[0]);
                switch (instructions[2])
                {
                    case "gain":
                        
                        datas.Add((instructions[0], instructions[10]), (int.Parse(instructions[3])));
                        break;
                    case "lose":
                        datas.Add((instructions[0], instructions[10]), -(int.Parse(instructions[3])));
                        break;

                }
            }
            int max = 0;
            foreach (var item in Day9.Permutate(members, members.Count-1))
            {
                var current = CalculateHappines(members, datas);
                if(current > max) max = current;
            }
            Console.WriteLine("Day13 Part One: "+ max);

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var datas = new Dictionary<(string, string), int>(); //(ki, ki melett), mennyit nyer/veszít
            var members = new List<string>();
            foreach (var line in input)
            {
                var instructions = line.Remove(line.Length - 1).Split(' ');
                //Console.WriteLine(instructions.Length);
                if (!members.Contains(instructions[0])) members.Add(instructions[0]);
                switch (instructions[2])
                {
                    case "gain":

                        datas.Add((instructions[0], instructions[10]), (int.Parse(instructions[3])));
                        break;
                    case "lose":
                        datas.Add((instructions[0], instructions[10]), -(int.Parse(instructions[3])));
                        break;

                }
            }
            members.Insert(0, "Me");
            for (int i = 1; i < members.Count-1; i++)
            {
                datas.Add(("Me", members[i]), 0);
                datas.Add((members[i], "Me"), 0);
            }
            int max = 0;
            foreach (var item in Day9.Permutate(members, members.Count - 1))
            {
                var current = CalculateHappines(members, datas);
                if (current > max) max = current;
            }
            Console.WriteLine("Day13 Part Two: " + max);
        }
        public static int CalculateHappines(IList<String> names, Dictionary<(string, string), int> helper)
        {
            int sum = 0;
            for (int i = 1; i < names.Count; i++)
            {
                if (helper.TryGetValue((names[i], names[i - 1]), out int val) ) sum += val;
                //Console.WriteLine(names[i] + " " + names[i - 1] + " " + val);
                if (helper.TryGetValue((names[i-1], names[i]), out val)) sum += val;
                //Console.WriteLine(names[i-1] + " " + names[i] + " " + val);

            }
            if (helper.TryGetValue((names[0], names[names.Count - 1]), out int valu)) sum += valu;
            //Console.WriteLine(names[0]+ " " + names[names.Count - 1] + " " + valu);
            if (helper.TryGetValue((names[names.Count - 1], names[0]), out valu)) sum += valu;
            //Console.WriteLine(names[names.Count-1] + " " + names[0] + " " + valu);


            return sum;
        }
    }
}
