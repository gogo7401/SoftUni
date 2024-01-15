using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arraySummary = new int[n * 2];
            int[] array0 = new int[n];
            int[] array1 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] temp = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int j = i * 2;
                arraySummary[j] = temp[0];
                arraySummary[j + 1] = temp[1];
            }
            // елементи за първи масив
            int step = 3;
            int ii = 0;
            array0[0] = arraySummary[0];
            int jj = 0;
            while ((jj + step) < arraySummary.Length)
            {
                jj += step;
                if (step == 3) { step = 1; }
                else { step = 3; }
                ii++;
                array0[ii] = arraySummary[jj];
            }
            // елементи за втори масив
            step = 1;
            ii = 0;
            array1[0] = arraySummary[1];
            jj = 1;
            while ((jj + step) < arraySummary.Length)
            {
                jj += step;
                if (step == 3) { step = 1; }
                else { step = 3; }
                ii++;
                array1[ii] = arraySummary[jj];
            }


            Console.WriteLine(String.Join(' ', array0));
            Console.WriteLine(String.Join(' ', array1));

            /*int n = int.Parse(Console.ReadLine());
            int[] firstNums = new int[n];
            int[] secondNums = new int[n];

            for (int i = 1; i <= n; i++)
            {

                int[] inputArr = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                foreach (var element in inputArr)
                {
                    if (i % 2 == 0)
                    {
                        secondNums[i - 1] = inputArr[0];
                        firstNums[i - 1] = inputArr[1];
                    }

                    else
                    {
                        secondNums[i - 1] = inputArr[1];
                        firstNums[i - 1] = inputArr[0];
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(firstNums[i] + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(secondNums[i] + " ");
            }
        */
        }
    }
}
