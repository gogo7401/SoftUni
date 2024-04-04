namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textilesQueue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicamentsStack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Dictionary<string, int> healingItems = new Dictionary<string, int>();

            int sum = 0; 
            bool isAllEmpty = false;

            while (true)
            {
                if (textilesQueue.Count == 0 && medicamentsStack.Count == 0)
                {
                    Console.WriteLine("Textiles and medicaments are both empty.");
                    isAllEmpty = true;
                    break;
                }

                if (textilesQueue.Count == 0)
                {
                    Console.WriteLine("Textiles are empty.");
                    break;
                }

                if (medicamentsStack.Count == 0)
                {
                    Console.WriteLine("Medicaments are empty.");
                    break;
                }


                int textil = textilesQueue.Dequeue();
                int medicament = medicamentsStack.Pop();
                sum = textil + medicament;
                bool isCreateHeal = false;

                if (sum == 30)
                {
                    if (healingItems.ContainsKey("Patch") == false)
                    {
                        healingItems.Add("Patch", 0);
                    }
                    healingItems["Patch"]++;
                    isCreateHeal = true;
                }

                if (sum == 40)
                {
                    if (healingItems.ContainsKey("Bandage") == false)
                    {
                        healingItems.Add("Bandage", 0);
                    }
                    healingItems["Bandage"]++;
                    isCreateHeal = true;
                }

                if (sum == 100)
                {
                    if (healingItems.ContainsKey("MedKit") == false)
                    {
                        healingItems.Add("MedKit", 0);
                    }
                    healingItems["MedKit"]++;
                    isCreateHeal = true;
                }

                if (sum > 100)
                {
                    if (healingItems.ContainsKey("MedKit") == false)
                    {
                        healingItems.Add("MedKit", 0);
                    }
                    healingItems["MedKit"]++;

                    sum -= 100;

                    medicamentsStack.Push(medicamentsStack.Pop() + sum);
                    isCreateHeal = true;
                }

                if (isCreateHeal == false)
                {
                    medicamentsStack.Push(medicament + 10);
                }


            }

            foreach (var item in healingItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (isAllEmpty == false)
            {
                if (textilesQueue.Count > 0) { Console.WriteLine($"Textiles left: {string.Join(", ", textilesQueue)}"); }
                if (medicamentsStack.Count > 0) { Console.WriteLine($"Medicaments left: {string.Join(", ", medicamentsStack)}"); }
            }


        }
    }
}
