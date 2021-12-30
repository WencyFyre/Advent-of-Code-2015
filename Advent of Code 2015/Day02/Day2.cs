using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day2 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day2\\input.txt");
        public void PartOne()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            int area = 0;
            foreach (var areawithx in input)
            {
                
                var lwh = areawithx.Split('x'); //lenth, width, height
                var l = Int32.Parse(lwh[0]);
                var w = Int32.Parse(lwh[1]);
                var h = Int32.Parse(lwh[2]);
                var side = l * w;
                var top = w * h;
                var front = h * l;
                var smallest = side > top ? (top > front ? front : top) : (side > front ? front : side); //try reading this
                area += (side * 2 + front * 2 + top * 2+ smallest);
            }
            Console.WriteLine("Day1 Part One: " + area.ToString());

        }

        public void PartTwo()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            int area = 0;
            foreach (var areawithx in input)
            {

                var lwh = areawithx.Split('x'); //lenth, width, height
                var l = Int32.Parse(lwh[0]);
                var w = Int32.Parse(lwh[1]);
                var h = Int32.Parse(lwh[2]);
                var side = l+l+w+w;
                var top = w+w +h+h;
                var front = h + h + l + l;
                var smallest = side > top ? (top > front ? front : top) : (side > front ? front : side); //try reading this
                area += (l*w*h+smallest);
            }
            Console.WriteLine("Day1 Part Two: " + area.ToString());
        }
    }
}
