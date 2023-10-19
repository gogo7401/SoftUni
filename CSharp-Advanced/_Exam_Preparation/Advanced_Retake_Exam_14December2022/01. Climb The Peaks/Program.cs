using System.Collections.Immutable;

namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var peaks = new Dictionary<string, int>()
            {
                {"Vihren", 80 },
                {"Kutelo", 90 },
                {"Banski Suhodol", 100 },
                {"Polezhan", 60 },
                {"Kamenitza", 70 },
            };

            var conqueredPeaks = new List<string>();

            var food = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            var stamina = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            while (true)
            {

                if ((food.Count == 0 || stamina.Count == 0) && peaks.Count > 0)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    break;
                }

                if (peaks.Count == 0)
                {
                    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
                    break;
                }
                
                
                var first = peaks.First();
                string firstPeak = first.Key;
                int firstLevel = first.Value;
                var currFood = food.Pop();
                var currStamina = stamina.Dequeue();
                var sum = currFood + currStamina;

                if (sum >= firstLevel)
                {
                    conqueredPeaks.Add(firstPeak);
                    peaks.Remove(firstPeak);
                }




            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                foreach (var peak in conqueredPeaks) 
                {
                    Console.WriteLine(peak.ToString()); 
                }
            }

        }
    }
}