using System;

namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double secondNumber = double.Parse(Console.ReadLine());
            double result = GetCalcutation(firstNumber, secondNumber, operation);
            Console.WriteLine(result);

        }

        private static double GetCalcutation(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;  
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;    
                    break;
                case "-":
                    result = firstNumber - secondNumber;    
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }
            return result;
        }
    }
}
