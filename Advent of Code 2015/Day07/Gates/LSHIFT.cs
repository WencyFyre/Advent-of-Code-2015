using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class LSHIFT: ILogicGate
    {
        public string Input;
        public string output;
        public int shiftValue;
        public ushort? Value;
        public ushort? outputValue;

        public LSHIFT(string input, string output, int shiftValue)
        {
            Input = input;
            this.output = output;
            this.shiftValue = shiftValue;
        }

        public ushort CalculateOutput()
        {
            if ((Value is null)) throw new Exception($"No input value for: {Input}");
            outputValue = (ushort)(Value.Value << shiftValue);
            return outputValue.Value;
        }

        public bool IsValueReady()
        {
            return Value is not null;
        }
        public(ushort, string)? OutputValue()
        {
            return this.outputValue.HasValue ? (this.outputValue.Value, this.output) : null;
        }
    }
}
