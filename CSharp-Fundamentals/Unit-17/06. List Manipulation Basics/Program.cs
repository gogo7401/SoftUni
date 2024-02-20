using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            int number, index;

            while (command != "end")
            {
                string[] line = command.Split();
                string operation = line[0];
                switch (operation)
                {
                    case "Add":
                        number = int.Parse(line[1]);
                        list.Add(number);
                        break;
                    case "Remove":
                        number = int.Parse(line[1]);
                        list.Remove(number);
                        break;
                    case "RemoveAt":
                        index = int.Parse(line[1]);
                        list.RemoveAt(index);
                        break;
                    case "Insert":
                        number = int.Parse(line[1]);
                        index = int.Parse(line[2]);
                        list.Insert(index, number);
                        break;
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
