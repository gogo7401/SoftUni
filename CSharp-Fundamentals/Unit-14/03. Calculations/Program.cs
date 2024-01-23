using System;

namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    PrintAdd(firstNumber, secondNumber);
                    break;
                case "multiply":
                    PrintMultiply(firstNumber, secondNumber);
                    break;
                case "subtract":
                    PrintSubtract(firstNumber, secondNumber);
                    break;
                case "divide":
                    PrintDivide(firstNumber, secondNumber);
                    break;
            }
        }

        static void PrintAdd(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber+secondNumber);
        }

        static void PrintMultiply(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void PrintSubtract(double firstNumber, double secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void PrintDivide(double firstNumber, double secondNumber)
        {
            if (secondNumber > 0)
            {
                Console.WriteLine(firstNumber / secondNumber);
            }
            
        }
    }
}
