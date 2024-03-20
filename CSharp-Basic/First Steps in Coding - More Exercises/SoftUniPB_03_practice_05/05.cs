//  05
using System;

namespace TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            h = h - 1;
            double koloni = Math.Truncate( h / 0.7);
            double redove = Math.Truncate(w/1.2);
   
            double rm = koloni * redove - 3;

            Console.WriteLine(rm);
        }
    }
}
