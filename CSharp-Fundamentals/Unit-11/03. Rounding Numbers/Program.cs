using System;
using System.Linq;

namespace _03._Rounding_Numbers
{
    internal class Program 
    {
        static void Main(string[] args)
        {
                double[] listOfNums = Console.ReadLine()
                                            .Split()
                                            .Select(double.Parse)
                                            .ToArray();

                for (int i = 0; i < listOfNums.Length; i++)
                {
                    Console.WriteLine($"{listOfNums[i]} => {(int)Math.Round(listOfNums[i], MidpointRounding.AwayFromZero)}");
                }
            
            /*decimal result;

            result = Math.Round(3.45m, 1, MidpointRounding.ToEven);
            Console.WriteLine($"{result} = Math.Round({3.45m}, 1, MidpointRounding.ToEven)");
            result = Math.Round(3.45m, 1, MidpointRounding.AwayFromZero);
            Console.WriteLine($"{result} = Math.Round({3.45m}, 1, MidpointRounding.AwayFromZero)");
            result = Math.Round(3.47m, 1, MidpointRounding.ToZero);
            Console.WriteLine($"{result} = Math.Round({3.47m}, 1, MidpointRounding.ToZero)\n");

            result = Math.Round(-3.45m, 1, MidpointRounding.ToEven);
            Console.WriteLine($"{result} = Math.Round({-3.45m}, 1, MidpointRounding.ToEven)");
            result = Math.Round(-3.45m, 1, MidpointRounding.AwayFromZero);
            Console.WriteLine($"{result} = Math.Round({-3.45m}, 1, MidpointRounding.AwayFromZero)");
            result = Math.Round(-3.47m, 1, MidpointRounding.ToZero);
            Console.WriteLine($"{result} = Math.Round({-3.47m}, 1, MidpointRounding.ToZero)\n");

            string line = "4.1;4.0;4.0;3.8;4.0;4.3;4.2;4.0";

            double temp = 0;

            double[] values = line.Split(';')
                .Select(double.Parse)
                .ToArray();

            foreach (double value in values)
            {
                Console.WriteLine($"{value:f1}");
            }*/
        }
    }
}
