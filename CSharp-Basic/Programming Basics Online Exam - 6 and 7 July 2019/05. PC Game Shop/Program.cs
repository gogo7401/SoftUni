using System;

namespace _05._PC_Game_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSoldGames = int.Parse(Console.ReadLine());
            string nameGame = "";
            int countHearthstone = 0;
            int countFornite = 0;
            int countOverwatch = 0;
            int countOthers = 0;

            for (int i = 1; i <= numberOfSoldGames; i++)
            {
                nameGame = Console.ReadLine();
                switch (nameGame)
                {
                    case "Hearthstone":
                        countHearthstone++;
                        break;
                    case "Fornite":
                        countFornite++;
                        break;
                    case "Overwatch":
                        countOverwatch++;
                        break;
                    default:
                        countOthers++;
                        break;
                }

            }
            int allSoldGames = countHearthstone + countFornite + countOverwatch + countOthers;
            Console.WriteLine($"Hearthstone - {countHearthstone*1.0/ allSoldGames * 100:f2}%");
            Console.WriteLine($"Fornite - {countFornite * 1.0 / allSoldGames * 100:f2}%");
            Console.WriteLine($"Overwatch - {countOverwatch * 1.0 / allSoldGames * 100:f2}%");
            Console.WriteLine($"Others - {countOthers * 1.0 / allSoldGames * 100:f2}%");

        }
    }
}
