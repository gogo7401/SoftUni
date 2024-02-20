using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> productsList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                productsList.Add(Console.ReadLine());
            }
            productsList.Sort();
            for (int i = 1; i <= productsList.Count; i++)
            {
                Console.WriteLine($"{i}.{productsList[i-1]}");
            }
            
        }
    }
}
