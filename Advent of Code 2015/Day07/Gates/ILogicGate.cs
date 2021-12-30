using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public interface ILogicGate
    {
        public ushort CalculateOutput();
        public bool IsValueReady();
        public (ushort, string)? OutputValue();
    }
}
