using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Lights
    {
        public List<List<int>> LightGrid { get; set; }
        public Lights(string[] input)
        {
            LightGrid = new List<List<int>>();
           // Console.WriteLine(LightGrid.Count);
            for (int i = 0; i < input.Length; i++)
            {
                LightGrid.Add(new List<int>());
                foreach (var ch in input[i])
                {
                    LightGrid[i].Add(ch == '.' ? 0 : 1);
                }
            }
        }
        public IEnumerable<(int, int)> GetNeighbors(int x, int y)
        {
            for (int i = -1; i < 2; i++)
                for (int j = -1; j < 2; j++)
                    if (x+i > -1 && x+i < LightGrid.Count && 
                        y+j > -1 && y+j < LightGrid.Count &&
                        !(x+i==x && y+j==y))
                        yield return (x + i, y + j);
        }

        public void SwitchOnCorners()
        {
            LightGrid[0][0] = 1;
            LightGrid[0][^1] = 1;
            LightGrid[^1][0] = 1;
            LightGrid[^1][^1] = 1;
        }

        public int CountLights(int a, int b)
        {
            int count = 0;
            foreach (var (x, y) in GetNeighbors(a,b)) 
                if (LightGrid[x][y] == 1) count++;
            return count;
        }

        public void CalcNextState()
        {
            var nextState = new List<List<int>>();
            // Console.WriteLine(LightGrid.Count);
            for (int i = 0; i < LightGrid.Count; i++)
            {
                nextState.Add(new List<int>());
                foreach (var ch in LightGrid[i])
                {
                    nextState[i].Add(ch);
                }
            }
            for (int i = 0; i < LightGrid.Count; i++)
                for (int j = 0; j < LightGrid[i].Count; j++)
                {
                    int c = CountLights(i, j);
                    if(LightGrid[i][j] == 1)
                    {
                        if(!(c ==2 || c ==3)) nextState[i][j] = 0;
                    }
                    else if(LightGrid[i][j] == 0)
                    {
                        if (c == 3) nextState[i][j] = 1;
                    }
                }
            LightGrid = nextState;
        }

        public int CountLightsInGrid()
        {
            int count = 0;
            foreach (var item in LightGrid)
                foreach (var light in item)
                {
                    if(light==1)count++;
                }
            return count;
        }

        public void PrintState()
        {
            Console.WriteLine("Printing state:");
            foreach (var item in LightGrid)
            {
                Console.Write("\n");
                foreach (var light in item)
                {
                 Console.Write(light == 1? "#" : "." );   
                }
            }
            Console.Write("\n");

        }
    }
}
