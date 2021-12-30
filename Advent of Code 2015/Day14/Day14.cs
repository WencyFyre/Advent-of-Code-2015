using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day14 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day14\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllLines(path);
            int winning = 0;
            foreach (var line in input) 
            {
                var instructions = line.Split(' ');
                int secs = 2503;
                int speed = int.Parse(instructions[3]);
                int duration = int.Parse(instructions[6]);
                int sleep = int.Parse(instructions[13]);
                int km = 0;
                do
                {
                    if (secs - duration >= 0)
                    {  
                        km += speed * duration; 
                        secs -= duration; 
                    }
                    else
                    {
                        km += secs * speed;
                        secs = 0;
                    }
                    if (secs - sleep >= 0)
                    {
                        secs -= sleep;
                    }
                    else
                    {
                        secs = 0;
                    }

                } while (secs!=0);
                winning = winning < km ? km : winning;
                //Console.WriteLine(instructions[0] + " " + km);
               
                
                
            }
            
            Console.WriteLine("Day14 Part One: "+ winning);

        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllLines(path);
            var points = new Dictionary<String, int>();
            var deers = new List<Reindeer>();
            foreach (var line in input)
            {
                var instructions = line.Split(' ');
                deers.Add(new Reindeer(instructions[0], int.Parse(instructions[3]), int.Parse(instructions[13]), int.Parse(instructions[6])));
                points.Add(instructions[0],0);
                //Console.WriteLine(deers.Last().ToString());
            }
            for (int i = 0; i < 2503; i++)
            {
                deers.ForEach((deer) => deer.AdvanceState());
                foreach (var deer in GetMaxKm(deers))
                {
                    if(points.TryGetValue(deer.Name, out int point)) 
                    {
                        points[deer.Name] = point+1;
                    }
                    //Console.WriteLine(deer.Name +" "+ (point+1));
                }

            }
        Console.WriteLine("Day14 Part Two: " + points.Max((key)=>key.Value));
        }
        public static IList<Reindeer> GetMaxKm(IList<Reindeer> deers)
        {
            var onthetop = deers[0];
            foreach (var deer in deers)
            {
                if (deer.km > onthetop.km) onthetop = deer;
            }
            return deers.Where((deer) => deer.km == onthetop.km).ToList();
        }
    }
}
