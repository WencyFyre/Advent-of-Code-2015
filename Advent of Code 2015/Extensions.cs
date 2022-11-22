using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public static class Extensions
    {
        public static int ParseToInt(this string str)
        {
            return int.Parse(str);
        }
        public static uint ParseToUInt(this string str)
        {
            return uint.Parse(str);
        }
        public static long ParseToLong(this string str)
        {
            return long.Parse(str);
        }
        
        public static bool IsEven(this uint num)
        {
            return num % 2 == 0;
        }
        public static bool IsEven(this int num)
        {
            return num % 2 == 0;
        }
    }
}
