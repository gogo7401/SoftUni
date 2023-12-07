using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strongNumber = Console.ReadLine();
            int sum = 0;
            int fact = 1;

            for (int i = 0; i < strongNumber.Length; i++)
            {
                
                for (int j = 1; j <= int.Parse(strongNumber[i].ToString()); j++)
                {
                    fact *= j;
                }
                sum += fact;
                fact = 1;
            }
            if (sum == int.Parse(strongNumber.ToString()))
            {
                Console.WriteLine("yes");
                //Console.WriteLine(sum);
            }
            else 
            { 
                Console.WriteLine("no");
                //Console.WriteLine(sum);
            }
        }

    }
}
