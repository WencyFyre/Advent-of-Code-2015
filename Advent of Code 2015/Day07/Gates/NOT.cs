using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class NOT: ILogicGate
    {
        public string Input;
        public string output;
        public ushort? Value;
        public ushort? outputValue;

        public NOT(string input, string output)
        {
            Input = input;
            this.output = output;
        }

        public ushort CalculateOutput()
        {
            if ((Value is null)) throw new Exception($"No input value for: {Input}");
            outputValue = (ushort)~Value.Value;
            return outputValue.Value;
        }

        public bool IsValueReady()
        {
            return Value is not null;
        }
        public (ushort, string)? OutputValue()
        {
            return this.outputValue.HasValue ? (this.outputValue.Value, this.output) : null;
        }
    }
}
