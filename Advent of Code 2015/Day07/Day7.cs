using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2015
{
    public class Day7 : IDaySolution

    {
        readonly string path = Path.Combine("C:\\Users\\wency\\source\\repos\\Advent of Code 2015\\Advent of Code 2015\\Day7\\input.txt");
        public List<ILogicGate> gates;
        ushort partOneSol;

        public void PartOne()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            gates = new();

            foreach (var line in input) //beolvasás
            {
                var instructions = line.Split(' ');
                switch (instructions.Length)
                {

                    case 3: //PASS
                        if(int.TryParse(instructions[0],out int parsedInput))
                        {
                            var pass = new PASS("",instructions[2])
                            {
                                Value = (ushort)parsedInput,
                            };
                            gates.Add(pass);
                        }
                        else 
                        { 
                            gates.Add(new PASS(instructions[0], instructions[2]));
                        }
                        break;
                    case 4://NOT
                        if (int.TryParse(instructions[1], out parsedInput))
                        {
                            var pass = new NOT("", instructions[3])
                            {
                                Value = (ushort)parsedInput,
                            };
                            gates.Add(pass);
                        }
                        else
                        {
                            gates.Add(new NOT(instructions[1], instructions[3]));
                        }
                        break;
                    case 5://innen még 3 fele ágazik
                        if (instructions[1] == "OR")
                        {
                            if (int.TryParse(instructions[0], out parsedInput))//csak az OR baloldalán szerepelhet szám alapból (igazábol egyik oldalon sem)
                            {
                                var pass = new OR("", instructions[2], instructions[4])
                                {
                                    leftValue = (ushort)parsedInput
                                };
                                gates.Add(pass);
                            }
                            else
                            {
                                gates.Add(new OR(instructions[0], instructions[2],instructions[4]));
                            }


                        }
                        else if (instructions[1] == "AND")
                        {
                            if (int.TryParse(instructions[0], out parsedInput))//csak az AND baloldalán szerepelhet szám
                            {
                                var pass = new AND("", instructions[2], instructions[4])
                                {
                                    leftValue = (ushort)parsedInput
                                };
                                gates.Add(pass);
                            }
                            else
                            {
                                gates.Add(new AND(instructions[0], instructions[2], instructions[4]));
                            }

                        }
                        else if (instructions[1] == "LSHIFT") // nem kell ellenőríni, hogy a kapott soban az első érték szám, mert nincs ilyen
                        {
                            gates.Add(new LSHIFT(instructions[0], instructions[4], Int32.Parse(instructions[2])));
                        }
                        else if (instructions[1] == "RSHIFT")// nem kell ellenőríni, hogy a kapott soban az első érték szám, mert nincs ilyen
                        {
                            gates.Add(new RSHIFT(instructions[0], instructions[4], Int32.Parse(instructions[2])));

                        }
                        break;

                    default:
                        break;

                }
                //Console.WriteLine(gates.Last().GetType());
            }
            do
            {
                foreach (var gate in gates)
                {
                    if (gate.IsValueReady())
                    {
                        gate.CalculateOutput();
                        foreach (var gatetomodify in gates)
                        {
                            if (gate == gatetomodify) continue;
                            else if (!gatetomodify.IsValueReady())
                            {

                                if (gatetomodify.GetType() == typeof(AND))
                                {
                                    //Console.WriteLine("AND-be megyek");
                                    var and = gatetomodify as AND;
                                    if (and.leftInput == gate.OutputValue()?.Item2)
                                    {
                                        and.leftValue = gate.OutputValue()?.Item1;
                                        //Console.WriteLine(and.leftValue + "ez jó?");
                                    }
                                    else if (and.rightInput == gate.OutputValue()?.Item2)
                                    {
                                        and.rightValue = gate.OutputValue()?.Item1;
                                        //Console.WriteLine(and.leftValue + "ez jó?");

                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(OR))
                                {
                                    var and = gatetomodify as OR;
                                    if (and.leftInput == gate.OutputValue()?.Item2)
                                    {
                                        and.leftValue = gate.OutputValue()?.Item1;
                                    }
                                    else if (and.rightInput == gate.OutputValue()?.Item2)
                                    {
                                        and.rightValue = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if(gatetomodify.GetType() == typeof(LSHIFT))
                                {
                                    var and = gatetomodify as LSHIFT;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(RSHIFT))
                                {
                                    var and = gatetomodify as RSHIFT;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(NOT))
                                {

                                    var and = gatetomodify as NOT;
                                    //Console.WriteLine("NOT megyek " + and.Input + " "+ gate.OutputValue().Item2);
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(PASS))
                                {
                                    var and = gatetomodify as PASS;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }

                            }
                        }
                    }
                }
            } while (!IsSimulationOver());
            PrintValues();
            Console.WriteLine("Day6 Part One: " + partOneSol.ToString());

        }
        public bool IsSimulationOver()
        {
            var count = 0;
            foreach (var gate in gates)
            {
                count++;
                //Console.WriteLine(gate.GetType());

                if (gate.OutputValue() is null) 
                {
                    //Console.WriteLine("false ág: " + count);
                    return false; 
                }
            }
           // Console.WriteLine("True " + count);
            return true;
        }

        public void PrintValues()
        {
            foreach(var gate in gates)
            {
                if (gate.OutputValue()?.Item2 == "a")
                {
                    //Console.WriteLine($"{gate.OutputValue()} !!!!!!!!!!!!!!!!!!!");
                    partOneSol = gate.OutputValue().Value.Item1;
                }
                
            }

        }

        public void PartTwo()
        {
            string[] input = System.IO.File.ReadAllLines(path);
            gates = new();


            foreach (var line in input) //beolvasás
            {
                var instructions = line.Split(' ');
                switch (instructions.Length)
                {

                    case 3: //PASS
                        
                        if (int.TryParse(instructions[0], out int parsedInput))
                        {
                            
                            var pass = new PASS("", instructions[2])
                            {
                                Value = (ushort)parsedInput,
                            };
                            if (instructions[2] == "b")
                            {
                                //Console.WriteLine($"átálítottam a B-t erre: {partOneSol}");
                                pass.Value = partOneSol;
                            }
                                gates.Add(pass);       
                        }
                        else
                        {
                            gates.Add(new PASS(instructions[0], instructions[2]));
                        }
                        break;
                    case 4://NOT
                        if (int.TryParse(instructions[1], out parsedInput))
                        {
                            var pass = new NOT("", instructions[3])
                            {
                                Value = (ushort)parsedInput,
                            };
                            gates.Add(pass);
                        }
                        else
                        {
                            gates.Add(new NOT(instructions[1], instructions[3]));
                        }
                        break;
                    case 5://innen még 3 fele ágazik
                        if (instructions[1] == "OR")
                        {
                            if (int.TryParse(instructions[0], out parsedInput))//csak az OR baloldalán szerepelhet szám alapból (igazábol egyik oldalon sem)
                            {
                                var pass = new OR("", instructions[2], instructions[4])
                                {
                                    leftValue = (ushort)parsedInput
                                };
                                gates.Add(pass);
                            }
                            else
                            {
                                gates.Add(new OR(instructions[0], instructions[2], instructions[4]));
                            }


                        }
                        else if (instructions[1] == "AND")
                        {
                            if (int.TryParse(instructions[0], out parsedInput))//csak az AND baloldalán szerepelhet szám
                            {
                                var pass = new AND("", instructions[2], instructions[4])
                                {
                                    leftValue = (ushort)parsedInput
                                };
                                gates.Add(pass);
                            }
                            else
                            {
                                gates.Add(new AND(instructions[0], instructions[2], instructions[4]));
                            }

                        }
                        else if (instructions[1] == "LSHIFT") // nem kell ellenőríni, hogy a kapott soban az első érték szám, mert nincs ilyen
                        {
                            gates.Add(new LSHIFT(instructions[0], instructions[4], Int32.Parse(instructions[2])));
                        }
                        else if (instructions[1] == "RSHIFT")// nem kell ellenőríni, hogy a kapott soban az első érték szám, mert nincs ilyen
                        {
                            gates.Add(new RSHIFT(instructions[0], instructions[4], Int32.Parse(instructions[2])));

                        }
                        break;

                    default:
                        break;

                }
                //Console.WriteLine(gates.Last().GetType());
            }
            do
            {
                foreach (var gate in gates)
                {
                    if (gate.IsValueReady())
                    {
                        gate.CalculateOutput();
                        foreach (var gatetomodify in gates)
                        {
                            if (gate == gatetomodify) continue;
                            else if (!gatetomodify.IsValueReady())
                            {

                                if (gatetomodify.GetType() == typeof(AND))
                                {
                                    //Console.WriteLine("AND-be megyek");
                                    var and = gatetomodify as AND;
                                    if (and.leftInput == gate.OutputValue()?.Item2)
                                    {
                                        and.leftValue = gate.OutputValue()?.Item1;
                                        //Console.WriteLine(and.leftValue + "ez jó?");
                                    }
                                    else if (and.rightInput == gate.OutputValue()?.Item2)
                                    {
                                        and.rightValue = gate.OutputValue()?.Item1;
                                        //Console.WriteLine(and.leftValue + "ez jó?");

                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(OR))
                                {
                                    var and = gatetomodify as OR;
                                    if (and.leftInput == gate.OutputValue()?.Item2)
                                    {
                                        and.leftValue = gate.OutputValue()?.Item1;
                                    }
                                    else if (and.rightInput == gate.OutputValue()?.Item2)
                                    {
                                        and.rightValue = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(LSHIFT))
                                {
                                    var and = gatetomodify as LSHIFT;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(RSHIFT))
                                {
                                    var and = gatetomodify as RSHIFT;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(NOT))
                                {

                                    var and = gatetomodify as NOT;
                                    //Console.WriteLine("NOT megyek " + and.Input + " "+ gate.OutputValue().Item2);
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }
                                else if (gatetomodify.GetType() == typeof(PASS))
                                {
                                    var and = gatetomodify as PASS;
                                    if (and.Input == gate.OutputValue()?.Item2)
                                    {
                                        and.Value = gate.OutputValue()?.Item1;
                                    }
                                }

                            }
                        }
                    }
                }
            } while (!IsSimulationOver());
            PrintValues();
            Console.WriteLine("Day6 Part Two: " + partOneSol.ToString());

        }


    }
}
