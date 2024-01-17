using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
         /*       int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int middleNumber = 1;
                int leftSum = 0;
                int rightSum = 0;   
                bool isEqual = false;
                if (line.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                while (middleNumber < line.Length)
                {
                    for (int i = 0; i < middleNumber; i++)
                    {
                        leftSum += line[i];
                    }
                    for (int i = middleNumber + 1; i < line.Length; i++)
                    {
                        rightSum += line[i];
                    }
                    if (leftSum == rightSum)
                    {
                        Console.WriteLine(middleNumber);
                        isEqual = true;
                        break;
                    }
                    middleNumber++;
                    leftSum = 0;
                    rightSum = 0;
                }
                if (!isEqual) { Console.WriteLine("no"); }
            */
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool findedEqualSums = false;

            for (int i = 0; i < elements.Length; i++)
            {
                int sumLeft = 0;
                int sumRight = 0;

                for (int right = i + 1; right < elements.Length; right++)
                {
                    sumRight += elements[right];
                }

                for (int left = 0; left < i; left++)
                {
                    sumLeft += elements[left];
                }

                if (sumLeft == sumRight)
                {
                    findedEqualSums = true;
                    Console.WriteLine(i);
                    break;
                }
            }

            if (!findedEqualSums)
            {
                Console.WriteLine("no");
            }
            
        }
    }
}
