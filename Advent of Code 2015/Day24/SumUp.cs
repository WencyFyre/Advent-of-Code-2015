using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Linq;



namespace Advent_of_Code_2015
{
    public class SumUp
    {
        private int _groups;
        private IList<long> _numbers;
        private IList<IOrderedEnumerable<long>> SumUps = new List<IOrderedEnumerable<long>>();
        public long Threshold { get; set; }
        public IList<long> numbers
        {
            get
            {
                return _numbers;
            }
            set
            {
                _numbers = value;
                Threshold = _numbers.Sum() / _groups; //can be assumed it is divisible by 3
            } 
        }

        public SumUp(IList<long> numbers,int groups)
        {
            this._groups = groups;
            this.numbers = numbers;
            SumUpRecursive(numbers, Threshold, new List<long>());
        }

        public IList<IOrderedEnumerable<long>> GetSumUps()
        {
            return SumUps;
        }

        private void SumUpRecursive(IList<long> numbers, long target, List<long> partial)
        {
            long s = 0;
            foreach (long x in partial) s += x;

            if (s == target)
            {
                //Console.WriteLine( String.Join(",", partial.ToArray()));
                SumUps.Add(partial.OrderBy(x => x));
            }

            if (s >= target)
                return;

            for (int i = 0; i < numbers.Count; i++)
            {
                List<long> remaining = new List<long>();
                long n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                List<long> partial_rec = new(partial);
                partial_rec.Add(n);
                SumUpRecursive(remaining, target, partial_rec);
            }
        }
    }
}
