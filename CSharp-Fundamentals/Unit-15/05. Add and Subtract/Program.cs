using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sumOneAndTwo = GetSum(firstNumber, secondNumber);
            int subtractSumAndThird = GetSubtract(sumOneAndTwo, thirdNumber);
            Console.WriteLine(subtractSumAndThird);
        }


        private static int GetSum(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;

            return sum;

        }
        private static int GetSubtract(int sumOneAndTwo, int thirdNumber)
        {
            int subtract = sumOneAndTwo - thirdNumber;

            return subtract;
        }
    }
}
