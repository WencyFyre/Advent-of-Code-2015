using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day4 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day4\\input.txt");
        public void PartOne()
        {
            var input = System.IO.File.ReadAllText(path, Encoding.ASCII);
            var md5 = MD5.Create();
            string firstfive = "";
            int counter = 0;
            do
            {
                counter++;
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input+counter.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new();
                for (int i = 0; i < 5; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                firstfive = sb.ToString().Substring(0,5);
                //Console.WriteLine(firstfive);
            } while (firstfive!="00000");
            Console.WriteLine("Day4 Part One: " + counter);


        }

        public void PartTwo()
        {
            var input = System.IO.File.ReadAllText(path, Encoding.ASCII);
            var md5 = MD5.Create();
            string firstfive = "";
            int counter = 0;
            do
            {
                counter++;
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input + counter.ToString());
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new();
                for (int i = 0; i < 6; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                firstfive = sb.ToString().Substring(0, 6);
                //Console.WriteLine(firstfive);
            } while (firstfive != "000000");
            Console.WriteLine("Day4 Part Two: " + counter);



        }
    }
}
