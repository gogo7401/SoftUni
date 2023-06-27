namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = line[0];
                string country = line[1];
                string city = line[2];

                if (continents.ContainsKey(continent) == false)
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (continents[continent].ContainsKey(country) == false)
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);   
            }

            //Europe:
            //Bulgaria->Sofia, Plovdiv

            foreach (var (continent, countryAndCities) in continents)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, cities) in countryAndCities)
                {
                    Console.WriteLine($"{country} -> " + string.Join(", ", cities));
                }


            }

        }
    }
}