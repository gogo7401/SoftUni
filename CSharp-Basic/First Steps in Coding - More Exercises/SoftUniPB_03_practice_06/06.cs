//  06
using System;

namespace Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cenaSkumria = double.Parse(Console.ReadLine());
            double cenaCaca = double.Parse(Console.ReadLine());
            double kilogramaPalamud = double.Parse(Console.ReadLine());
            double kilogramaSafrid = double.Parse(Console.ReadLine());
            int kilogramaMidi = int.Parse(Console.ReadLine());

            double cenaMidi = 7.50;
            double cenaPalamud = cenaSkumria * 1.6;
            double cenaSafrid = cenaCaca * 1.8;

            double suma = cenaPalamud * kilogramaPalamud + cenaSafrid * kilogramaSafrid + cenaMidi * kilogramaMidi; 


            Console.WriteLine($"{suma:F2}");
        }
    }
}
