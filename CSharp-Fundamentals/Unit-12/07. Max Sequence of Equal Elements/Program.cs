using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;
            int maxCount = 0;
            string longestSequence = "";
            string longestSequenceTemp = "";

            for (int i = 0; i < line.Length; i++)
            {
                for (int j = i; j < line.Length; j++)
                {
                    if (line[i] == line[j])
                    {
                        longestSequenceTemp += line[j] + " ";
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (maxCount < count)
                {
                    longestSequence = longestSequenceTemp;
                    maxCount = count;
                }
                longestSequenceTemp = "";
                count = 0;
            }
            Console.WriteLine(longestSequence);
        }
    }
}
