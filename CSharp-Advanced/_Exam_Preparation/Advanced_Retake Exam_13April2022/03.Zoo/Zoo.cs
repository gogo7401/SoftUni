using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        //private readonly List<Animal> Animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var list = Animals.FindAll(x => x.Species == species);

            foreach (var animal in list)
            {
                Animals.Remove(animal);
            }

            return list.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(a => a.Diet == diet);
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(a => a.Weight == weight); 
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var list = Animals.FindAll(a => a.Length >= minimumLength && a.Length <= maximumLength);

            return $"There are {list.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
