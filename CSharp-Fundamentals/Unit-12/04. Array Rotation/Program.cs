using System;
using System.Linq;

namespace _04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ').ToArray();
            int beginFrom = int.Parse(Console.ReadLine());
            int startIndexArray = 0;
            if (beginFrom < numbers.Length)
            {
                startIndexArray = beginFrom;
            }
            else
            {
                startIndexArray = Math.Abs(numbers.Length - beginFrom);
            }
            
            for (int i = startIndexArray; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            for (int i = 0; i < startIndexArray; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}
