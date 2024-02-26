using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string[] manipulate = Console.ReadLine().Split();   

            while (manipulate[0] != "end")
            {
                string command = manipulate[0];
                int element, position;
                switch (command)
                {
                    case "Delete":
                        element = int.Parse(manipulate[1]);
                        list.RemoveAll(x => x == element);  
                        break;
                    case "Insert":
                        element = int.Parse(manipulate[1]);
                        position = int.Parse(manipulate[2]);
                        list.Insert(position, element);
                        break;
                }

                manipulate = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
