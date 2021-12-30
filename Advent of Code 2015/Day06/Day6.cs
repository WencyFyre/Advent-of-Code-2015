using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day6 : IDaySolution

    {
        string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day6\\input.txt");
        bool[,] lights = new bool[1000, 1000];
        int[,] lightsBright = new int[1000, 1000];

        char[] seperators = { ' ', ',' };


        public void PartOne()
        {
            InitMatrix(lights);
            string[] input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                var instructions = line.Split(seperators);
                
                switch (instructions[0])
                {
                    case "turn":
                        if (instructions[1] == "off")
                        {
                            SwitchLights(Mode.OFF, 
                                Int32.Parse(instructions[2]), 
                                Int32.Parse(instructions[5]), 
                                Int32.Parse(instructions[3]), 
                                Int32.Parse(instructions[6]));
                        }
                        else
                        {
                            SwitchLights(Mode.ON,
                               Int32.Parse(instructions[2]),
                               Int32.Parse(instructions[5]),
                               Int32.Parse(instructions[3]),
                               Int32.Parse(instructions[6]));
                        }
                        break;
                    case "toggle":
                        SwitchLights(Mode.TOGGLE,
                             Int32.Parse(instructions[1]),
                             Int32.Parse(instructions[4]),
                             Int32.Parse(instructions[2]),
                             Int32.Parse(instructions[5]));
                        break;
                }
            }
            int counter = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (lights[i, j]) counter++;
                }
            }
            Console.WriteLine("Day6 Part One: " + counter.ToString());

        }

        private void InitMatrix(bool[,] lights)
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    lights[i, j] = false;
                }
            }
        }
        private void InitMatrixBright(int[,] lights)
        {
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    lights[i, j] = 0;
                }
            }
        }



        public void PartTwo()
        {
            InitMatrixBright(lightsBright);
            string[] input = System.IO.File.ReadAllLines(path);
            foreach (var line in input)
            {
                var instructions = line.Split(seperators);

                switch (instructions[0])
                {
                    case "turn":
                        if (instructions[1] == "off")
                        {
                            SwitchLightsBright(Mode.OFF,
                                Int32.Parse(instructions[2]),
                                Int32.Parse(instructions[5]),
                                Int32.Parse(instructions[3]),
                                Int32.Parse(instructions[6]));
                        }
                        else
                        {
                            SwitchLightsBright(Mode.ON,
                               Int32.Parse(instructions[2]),
                               Int32.Parse(instructions[5]),
                               Int32.Parse(instructions[3]),
                               Int32.Parse(instructions[6]));
                        }
                        break;
                    case "toggle":
                        SwitchLightsBright(Mode.TOGGLE,
                             Int32.Parse(instructions[1]),
                             Int32.Parse(instructions[4]),
                             Int32.Parse(instructions[2]),
                             Int32.Parse(instructions[5]));
                        break;
                }
            }
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    sum+=lightsBright[i, j];
                }
            }
            Console.WriteLine("Day6 Part One: " + sum.ToString());
        }

        public void SwitchLights(Mode mod, int xstart,int  xend,int  ystart,int  yend)
        {
            switch (mod)
            {
                case Mode.ON:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <=yend; j++)
                        {
                            lights[i, j] = true;
                        }
                    }
                    break;
                case Mode.OFF:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <= yend; j++)
                        {
                            lights[i, j] = false;
                        }
                    }
                    break;
                case Mode.TOGGLE:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <= yend; j++)
                        {
                            lights[i, j] = !lights[i, j];
                        }
                    }
                    break;
            }
        }
        public void SwitchLightsBright(Mode mod, int xstart, int xend, int ystart, int yend)
        {
            switch (mod)
            {
                case Mode.ON:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <= yend; j++)
                        {
                            lightsBright[i, j]++;
                        }
                    }
                    break;
                case Mode.OFF:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <= yend; j++)
                        {
                           if(lightsBright[i,j]>0) lightsBright[i, j]--;
                        }
                    }
                    break;
                case Mode.TOGGLE:
                    for (int i = xstart; i <= xend; i++)
                    {
                        for (int j = ystart; j <= yend; j++)
                        {
                            lightsBright[i, j]+=2;
                        }
                    }
                    break;
            }
        }
    }

    public enum Mode
    {
        ON,
        OFF,
        TOGGLE
    }
}
