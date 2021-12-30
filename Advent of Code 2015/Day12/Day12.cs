using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2015
{
    public class Day12 : IDaySolution
    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day12\\input.json");
        public void PartOne()
        {
            string input = System.IO.File.ReadAllText(path);
            var parsedInput = Regex.Matches(input, "-?[0-9]+").ToList();
            int sum = 0;
            foreach (var num in parsedInput)
            {
                sum+=int.Parse(num.Value);
            }
            Console.WriteLine("Day12 Part One: "+ sum);

        }

        public void PartTwo()
        {
            string input = System.IO.File.ReadAllText(path);
            var json = JArray.Parse(input);
            
            //json.Values().


            Console.WriteLine("Day12 Part Two: " + GetSum(json, "red"));
        }

        long GetSum(JObject o, string avoid = null)
        {
            bool shouldAvoid = o.Properties()
                .Select(a => a.Value).OfType<JValue>()
                .Select(v => v.Value).Contains(avoid);
            if (shouldAvoid) return 0;

            return o.Properties().Sum((dynamic a) => (long)GetSum(a.Value, avoid));
        }

        long GetSum(JArray arr, string avoid) => arr.Sum((dynamic a) => (long)GetSum(a, avoid));

        long GetSum(JValue val, string avoid) => val.Type == JTokenType.Integer ? (long)val.Value : 0;
    }
}
