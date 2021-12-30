using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class OR:  ILogicGate
    {
        public string leftInput;
        public string rightInput;
        public string output;
        public ushort? leftValue;
        public ushort? rightValue;
        public ushort? outputValue;

        public OR(string leftInput, string rightInput, string output)
        {
            this.leftInput = leftInput;
            this.rightInput = rightInput;
            this.output = output;
        }

        public ushort CalculateOutput()
        {
            if ((leftValue is null ) || (rightValue is null)) throw new Exception($"No input values for: {leftInput} and {rightInput}");
            outputValue = (ushort)(leftValue.Value | rightValue);
            return outputValue.Value;
        }

        public bool IsValueReady()
        {
            return (leftValue is not null) && (rightValue is not null);
        }
        public (ushort, string)? OutputValue()
        {
            return this.outputValue.HasValue ? (this.outputValue.Value, this.output) : null;
        }
    }
}
