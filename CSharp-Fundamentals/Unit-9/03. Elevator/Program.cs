using System;

namespace _03._Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeoples = int.Parse(Console.ReadLine());
            int capacityElevator = int.Parse(Console.ReadLine());

            int courses = 0;

            courses = numberOfPeoples / capacityElevator;
            if (numberOfPeoples % capacityElevator == 0)
            {
                if (courses==0) { Console.WriteLine(courses+1); }
                else { Console.WriteLine(courses); }
            }
            else { Console.WriteLine(courses + 1); }

        }
    }
}
