using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|') 
                .ToList();
            List<string> result = new List<string>();   

            for (int i = list.Count - 1; i >= 0; i--)
            {

                string[] temp = list[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < temp.Length; j++)
                {
                    result.Add(temp[j]);
                }
                

            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
