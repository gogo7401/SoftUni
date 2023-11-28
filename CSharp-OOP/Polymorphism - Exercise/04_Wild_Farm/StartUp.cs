namespace _04_Wild_Farm
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var increaseWeight = new Dictionary<string, double>()
                                    {{ "Hen", 0.35 },
                                     { "Owl", 0.25 },
                                     { "Mouse", 0.10 },
                                     { "Cat", 0.30 },
                                     { "Dog", 0.40 },
                                     { "Tiger", 1.00 }};


            var eatFood = new Dictionary<string, List<string>>() 
                                {    { "Hen", new List<string> { "Vegetable", "Fruit", "Meat", "Seeds" } },
                                     { "Owl", new List<string> { "Meat" } },
                                     { "Mouse", new List<string> { "Vegetable", "Fruit" } },
                                     { "Cat", new List<string> { "Vegetable", "Meat" } },
                                     { "Dog", new List<string> { "Meat" } },
                                     { "Tiger", new List<string> { "Meat" } }    
                                };


            var listOfAnimals = new List<Animal>();

            while (true)
            {
                string evenLine = Console.ReadLine();
                if (evenLine == "End")
                {
                    break;
                }
                string oddLine = Console.ReadLine();

                string[] token = evenLine.Split(" ");

                string inType = token[0];
                string inName = token[1];
                double inWeight = double.Parse(token[2]);

                Animal animal = null;

                if (inType == "Cat")
                {
                    string inLivingRegion = token[3];
                    string inBreed = token[4];
                    animal = new Cat(inName, inWeight, inLivingRegion, inBreed);
                    
                }
                else if (inType == "Tiger")
                {
                    string inLivingRegion = token[3];
                    string inBreed = token[4];
                    animal = new Tiger(inName, inWeight, inLivingRegion, inBreed);
                }
                else if (inType == "Owl")
                {
                    double inWingSize = double.Parse(token[3]);
                    animal = new Owl(inName, inWeight, inWingSize);
                }
                else if (inType == "Hen")
                {
                    double inWingSize = double.Parse(token[3]);
                    animal = new Hen(inName, inWeight, inWingSize);
                }
                else if (inType == "Mouse")
                {
                    string inLivingRegion = token[3];
                    animal = new Mouse(inName, inWeight, inLivingRegion);   
                }
                else if (inType == "Dog")
                {
                    string inLivingRegion = token[3];
                    animal = new Dog(inName, inWeight, inLivingRegion);
                }
                else
                {
                    continue;
                }

                animal.ProducingSound();

                string kindOfFood = oddLine.Split(" ")[0];
                double pieceOfFood = double.Parse(oddLine.Split(" ")[1]);
                double incWeight = pieceOfFood;

                if (eatFood[inType].Contains(kindOfFood))
                {
                    incWeight *= increaseWeight[inType];
                }
                else
                {
                    pieceOfFood = 0;
                    incWeight = 0;
                    Console.WriteLine($"{inType} does not eat {kindOfFood}!");
                }

                animal.Weight += incWeight;
                animal.FoodEaten = (int) pieceOfFood;

                listOfAnimals.Add(animal);

            }

            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine(animal.ToString());
            }

        }
    }
}