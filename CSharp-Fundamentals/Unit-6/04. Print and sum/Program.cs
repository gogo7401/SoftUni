using System;

namespace _04._Print_and_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startnumber = int.Parse(Console.ReadLine());    
            int endNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            string pattern = "";

            for (int i = startnumber; i <= endNumber; i++)
            {
                sum += i;
                pattern += (i + " ");
            }
            Console.WriteLine(pattern);
            Console.WriteLine("Sum: " + sum);
        }
    }
}
