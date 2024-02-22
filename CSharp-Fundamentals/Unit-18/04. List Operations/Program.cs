using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            string[] manipulation = Console.ReadLine().Split(' ');
            int maxIndex = list.Count-1;  // ??
            int number, index, count;

            while (manipulation[0] != "End")
            {
                string command = manipulation[0];
                switch (command)
                {
                    case "Add":
                        number = int.Parse(manipulation[1]);
                        list.Add(number);
                        break;
                    case "Insert":
                        number = int.Parse(manipulation[1]);
                        index = int.Parse(manipulation[2]);
                        if (index <0 || index > maxIndex)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.Insert(index, number);
                            maxIndex = list.Count-1;  
                        }
                        break;
                    case "Remove":
                        index = int.Parse(manipulation[1]);
                        if (index < 0 || index > maxIndex)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(index);
                            maxIndex = list.Count-1;
                        }
                        break;
                    case "Shift":
                        string leftRight = manipulation[1];
                        if (leftRight == "left")
                        {
                            count = int.Parse(manipulation[2]);
                            for (int i = 0; i < count; i++)
                            {
                                list.Add(list[0]);
                                list.RemoveAt(0);
                            }
                        }
                        else if (leftRight == "right")
                        {
                            count = int.Parse(manipulation[2]);
                            for (int i = 0; i < count; i++)
                            {
                                int temp = list[list.Count-1]; 
                                list.RemoveAt(list.Count - 1);
                                list.Insert(0, temp);   
                            }
                        }

                        break;

                }

                manipulation = Console.ReadLine().Split(' ');
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
