using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintNxN(n);
        }

        private static void PrintNxN(int n)
        {
            string pattern = "";
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    pattern += n.ToString() + " ";
                }
                Console.WriteLine(pattern);
                pattern = "";

            }
        }
    }
}
