using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            var location = new Dictionary<int, string>()
            {
                { 40, "Sink" },
                { 50, "Oven"},
                { 60, "Countertop"},
                { 70, "Wall"},
            };


            var kitchen = new Dictionary<string, int>();

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int white = whiteTiles.Pop();
                int grey = greyTiles.Dequeue();
                int largerTile = white + grey;

                if (white == grey)
                {
                    if (location.ContainsKey(largerTile))
                    {
                        if (kitchen.ContainsKey(location[largerTile]) == false)
                        {
                            kitchen.Add(location[largerTile], 0);
                        }
                        kitchen[location[largerTile]]++;
                    }
                    else
                    {
                        if (kitchen.ContainsKey("Floor") == false)
                        {
                            kitchen.Add("Floor", 0);

                        }
                        kitchen["Floor"]++;
                    }
                }
                else
                {
                    white /= 2;
                    whiteTiles.Push(white);
                    greyTiles.Enqueue(grey);
                }


                

            }

            if (whiteTiles.Count > 0)
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            else
            {
                Console.WriteLine("White tiles left: none");
            }

            if (greyTiles.Count > 0)
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            else
            {
                Console.WriteLine("Grey tiles left: none");
            }

            foreach (var item in kitchen.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
