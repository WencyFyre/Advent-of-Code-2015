using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day20 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day20\\input.txt");
        public void PartOne()
        {
            int input = File.ReadAllText(path).ParseToInt();
            int c = 665200;
            int sum;
            do
            {
                c++;
                sum = GetNumTimesNSum(GetDivs(c),10);
                //Console.WriteLine(c + " sum: " + sum);
            } while (sum <= input);
            Console.WriteLine("Day20 Part One: " + c);

        }

        public void PartTwo()
        {
            int input = File.ReadAllText(path).ParseToInt();
            int c = 700000;
            int sum;
            do
            {
                c++;
                sum = GetNumTimesNSum(GetNumFiltered(GetDivs(c), c),11);
                //Console.WriteLine(c + " sum: " + sum);
            } while (sum <= input);

            Console.WriteLine("Day20 Part Two: " + c);
        }

        public static IEnumerable<int> GetDivs(int num) 
        {
            yield return num;
            yield return 1;
            for (int i = 2; i < (num/2)+1; i++)
            {
                if (num % i == 0) yield return i;
            }
        }

        public static int GetNumTimesNSum(IEnumerable<int> nums, int n)
        {
            return nums.Sum(x => x * n);
        }

        public static IEnumerable<int> GetNumFiltered(IEnumerable<int> nums, int n)
        {
           return nums.Where(x =>
           {
               return n/x < 51;
           });

        }
        


    }
}
