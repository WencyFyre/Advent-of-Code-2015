using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day3 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day3\\input.txt");
        public void PartOne()
        {
            string input = System.IO.File.ReadAllText(path);
            var houses = new HashSet<(int x,int y)>();
            var currentPosition = (x: 0,y: 0);
            houses.Add(currentPosition);
            
            foreach (var direction in input)
            {
                switch (direction)
                {
                    case '^':
                        currentPosition.x++;
                        break;
                    case '>':
                        currentPosition.y++;
                        break;
                    case 'v':
                        currentPosition.x--;
                        break;
                    case '<':
                        currentPosition.y--;
                        break;
                }
                houses.Add(currentPosition);

            }
            Console.WriteLine("Day3 Part One: " + houses.Count.ToString());

        }

        public void PartTwo()
        {
            string input = System.IO.File.ReadAllText(path);
            var houses = new HashSet<(int x, int y)>();
            var santaPosition = (x: 0, y: 0);
            var robotPosition = (x: 0, y: 0);
            houses.Add(santaPosition);
            var santasTurn = true;
            foreach (var direction in input)
            {
                switch (direction)
                {
                    case '^' when santasTurn:
                        santaPosition.x++;
                        break;
                    case '>' when santasTurn:
                        santaPosition.y++;
                        break;
                    case 'v' when santasTurn:
                        santaPosition.x--;
                        break;
                    case '<' when santasTurn:
                        santaPosition.y--;
                        break;
                    case '^' when !santasTurn:
                        robotPosition.x++;
                        break;
                    case '>' when !santasTurn:
                        robotPosition.y++;
                        break;
                    case 'v' when !santasTurn:
                        robotPosition.x--;
                        break;
                    case '<' when !santasTurn:
                        robotPosition.y--;
                        break;
                }
                houses.Add(santaPosition);
                houses.Add(robotPosition);
                santasTurn = !santasTurn;
            }
            Console.WriteLine("Day3 Part One: " + houses.Count.ToString());

        }
    }
}
