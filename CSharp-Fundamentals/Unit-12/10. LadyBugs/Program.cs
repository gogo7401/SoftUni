using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] field = new int[sizeOfField];
            int[] ladyBugs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < ladyBugs.Length; i++)
            {
                if (ladyBugs[i]>=0 && ladyBugs[i]<sizeOfField) { field[ladyBugs[i]] = 1; }
            }
            string[] moved = new string[3];
            //Console.WriteLine(String.Join(" ", field));
            string line; 

            while ((line = Console.ReadLine()) != "end")
            {
                moved = line.Split(' ').ToArray();
                if (int.Parse(moved[0]) < 0 || int.Parse(moved[0]) >= sizeOfField)
                {
                    continue;
                }

                //Console.WriteLine(String.Join(" ", moved));
                int nextStep = 0;

                if (field[int.Parse(moved[0])] == 0)
                {
                    continue;
                }
                field[int.Parse(moved[0])] = 0;
                nextStep = int.Parse(moved[2]);
                if (moved[1] == "left") { nextStep *= -1; }
                int nextIndex = int.Parse(moved[0]) + nextStep;
                while (nextIndex >= 0 && nextIndex < sizeOfField && field[nextIndex] ==1)
                {
                    nextIndex += nextStep; 
                }
                if (nextIndex < 0 || nextIndex >= sizeOfField)
                {
                    continue;
                }

                field[nextIndex] = 1;

                // line = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
