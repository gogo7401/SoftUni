using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> listOne = Console.ReadLine().Split().ToList();
            List<string> listTwo = Console.ReadLine().Split().ToList();
            List<string> result = new List<string>();   

            int countMin = Math.Min(listOne.Count, listTwo.Count);
            for (int i = 0; i < countMin; i++)
            {
                result.Add(listOne[i]);
                result.Add(listTwo[i]);
            }
            if (listOne.Count > listTwo.Count)
            {
                for (int i = countMin; i < listOne.Count; i++)
                {
                    result.Add(listOne[i]);
                }
            }
            else
            {
                for (int i = countMin; i < listTwo.Count; i++)
                {
                    result.Add(listTwo[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
