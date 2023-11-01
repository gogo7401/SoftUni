using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var meals = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var caloriesPerDay = new Stack<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse));



            var mealCalories = new Dictionary<string, int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 },
            };

            int numberOfMeals = meals.Count;
            int remainder = 0;

            while (meals.Count > 0 && caloriesPerDay.Count > 0)
            {
                string food = meals.Dequeue();
                int foodCalories = mealCalories[food];
                int calForDay = caloriesPerDay.Pop();

                //calForDay += remainder;

                if (calForDay - foodCalories >= 0)
                {
                    calForDay -= foodCalories;
                    if (calForDay > 0) { caloriesPerDay.Push(calForDay); }

                }
                else
                {
                    remainder = Math.Abs(calForDay - foodCalories);
                    if (caloriesPerDay.Any())
                    {
                        int cal = caloriesPerDay.Pop();
                        cal -= remainder;
                        caloriesPerDay.Push(cal);
                    }

                }



            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
