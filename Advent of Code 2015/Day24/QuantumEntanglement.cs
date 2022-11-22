using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public static class QuantumEntanglement
    {
        public static long CalcQuantumEntanglement(this IList<long> list)
        {
            long prod = 1;
            for (int i = 0; i < list.Count; i++)
            {
                prod = prod * list[i];
            }
            return prod;
        }
    }
}
