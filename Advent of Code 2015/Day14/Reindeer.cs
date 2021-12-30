using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Reindeer
    {
        public string Name { get; private set; }
        public int Speed { get; private set; }
        public int Sleep { get;private set; }
        public int Duration { get;private set; }
        public int km { get; set; }

        public int boost ;
        public int sleepingtime ;

        public Reindeer(string name, int speed, int sleep, int duration)
        {
            Name = name;
            Speed = speed;
            Sleep = sleep;
            Duration = duration;
            boost = duration;
            sleepingtime = sleep;
        }
        public override string ToString()
        {
            return $"{Name}, speed:{Speed} km/h for {Duration} and sleeps for: {Sleep}";
        }
    }

    public static class ReindeerExtensions
    {
        public static void AdvanceState(this Reindeer deer)
        {
            if (deer.boost - 1 >= 0)
            {
                deer.km += deer.Speed;
                deer.boost--;
            }
            else
            {
                if (deer.sleepingtime-1 >= 0)
                {
                    deer.sleepingtime--;
                }
                else
                {
                    deer.boost = deer.Duration;
                    deer.sleepingtime = deer.Sleep;
                    AdvanceState(deer);
                }
            }

        }
    }
}
