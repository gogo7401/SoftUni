using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int wagonCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            string passengers;

            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    passengers = input[1];
                    train.Add(int.Parse(passengers));
                }
                else
                {
                    passengers = input[0];
                    for (int i = 0; i < train.Count; i++)
                    {
                        if ((int.Parse(passengers) + train[i]) <= wagonCapacity)
                        {
                            train.Insert(i, (int.Parse(passengers) + train[i]));
                            train.RemoveAt(i+1);  
                            break;
                        }
                    }
                }

                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", train));
        }
    }
}
