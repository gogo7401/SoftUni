using System;

namespace _05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            string inputNumberString;
            int sum = 0;    

            for (int c = 1; c <= inputNumber; c++)
            {
                inputNumberString = c.ToString();
                sum = 0;
                for (int i = 0; i < inputNumberString.Length; i++)
                {
                    sum += int.Parse(inputNumberString[i].ToString());  
                }
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{c} -> True");
                }
                else { Console.WriteLine($"{c} -> False"); }
            }
            
        }
    }
}
