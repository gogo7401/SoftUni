using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
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
            bool isChanged = false;

            while (command != "end")
            {
                string[] line = command.Split();
                string operation = line[0];
                switch (operation)
                {
                    case "Add":
                        number = int.Parse(line[1]);
                        list.Add(number);
                        isChanged = true;
                        break;
                    case "Remove":
                        number = int.Parse(line[1]);
                        list.Remove(number);
                        isChanged = true;
                        break;
                    case "RemoveAt":
                        index = int.Parse(line[1]);
                        list.RemoveAt(index);
                        isChanged = true;
                        break;
                    case "Insert":
                        number = int.Parse(line[1]);
                        index = int.Parse(line[2]);
                        list.Insert(index, number);
                        isChanged = true;
                        break;
                    case "Contains":
                        number = int.Parse(line[1]);
                        if (list.Contains(number))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;
                    case "PrintEven":
                        Console.WriteLine(string.Join(" ", list.Where(x => x % 2 == 0)));
                        break;
                    case "PrintOdd":
                        Console.WriteLine(string.Join(" ", list.Where(x => x % 2 != 0)));
                        break;
                    case "GetSum":
                        Console.WriteLine(string.Join(" ", list.Sum()));
                        break;
                    case "Filter":
                        string condition = line[1];
                        number = int.Parse(line[2]);    
                        if (condition == "<")
                        {
                            Console.WriteLine(string.Join(" ", list.Where(x => x < number)));
                        }
                        else if (condition == ">")
                        {
                            Console.WriteLine(string.Join(" ", list.Where(x => x > number)));
                        }
                        else if (condition == ">=")
                        {
                            Console.WriteLine(string.Join(" ", list.Where(x => x >= number)));
                        }
                        else if (condition == "<=")
                        {
                            Console.WriteLine(string.Join(" ", list.Where(x => x <= number)));
                        }
                        break;
                }


                command = Console.ReadLine();
            }
            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", list));

            }
        }
    }
}
