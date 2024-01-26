using System;

namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputType = Console.ReadLine();
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            switch (inputType)
            {
                case "int":
                    int firstInt = int.Parse(first);
                    int secondInt = int.Parse(second);
                    GetMax(firstInt, secondInt);
                    break;
                case "char":
                    char firstChar = char.Parse(first);
                    char secondChar = char.Parse(second);
                    GetMax(firstChar, secondChar);
                    break;
                case "string":
                    GetMax(first, second);
                    break;
            }
            
        }

        static void GetMax(int first, int second)
        {
            if (first > second)
            {
                Console.WriteLine(first);
            }
            else { Console.WriteLine(second); }
        }

        static void GetMax(char first, char second)
        {
            if (first > second)
            {
                Console.WriteLine(first);
            }
            else { Console.WriteLine(second); }
        }

        static void GetMax(string first, string second)
        {
            if (first.CompareTo(second) > 0)
            {
                Console.WriteLine(first);
            }
            else { Console.WriteLine(second); } 
        }
    }
}
