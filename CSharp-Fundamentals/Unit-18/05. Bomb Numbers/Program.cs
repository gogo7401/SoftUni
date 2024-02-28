using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> lineNumbers = Console.ReadLine() // 1 2 2 4 2 2 2 9
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bombNumbers = Console.ReadLine()  // 4 2
                .Split()
                .Select(int.Parse)
                .ToList();
            // calculate
            for (int i = 0; i < lineNumbers.Count; i++)
            {
                if (lineNumbers[i] == bombNumbers[0])
                {
                    if ((i - bombNumbers[1]) > 0)
                    {
                        int beginPower = i - bombNumbers[1];
                        int countPower = (bombNumbers[1] * 2 + 1);
                        if (countPower + i > lineNumbers.Count)
                        {
                            countPower -= Math.Abs(beginPower + countPower - lineNumbers.Count);
                        }
                        lineNumbers.RemoveRange(beginPower, countPower);
                        i = -1;
                    }
                    else
                    {
                        int beginPower = 0;
                        int countPower = (bombNumbers[1]*2+1) - Math.Abs(i - bombNumbers[1]);
                        lineNumbers.RemoveRange(beginPower, countPower);
                        i = -1;
                    }
                }
                
            }

            // Print output
            Console.WriteLine(lineNumbers.Sum());
        }
    }
}
