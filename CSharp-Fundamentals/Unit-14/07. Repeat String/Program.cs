using System;

namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();  
            int count = int.Parse(Console.ReadLine());
            string result = PrintString(input, count);
            Console.WriteLine(result);

        }

        static string PrintString(string input, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += input;
            }
            return result;
        }
    }
}
