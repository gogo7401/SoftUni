using System;

namespace _01._Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            string age = Console.ReadLine();
            string averageGrade = Console.ReadLine();

            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {averageGrade}");
        }
    }
}
