namespace _03_Raiding
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var heroes = new List<BaseHero>();

            int countOfHeroes = int.Parse(Console.ReadLine());

            while (countOfHeroes != heroes.Count) 
            {
                string nameHero = Console.ReadLine();
                string typeHero = Console.ReadLine();
                BaseHero heroType = CreateHero(nameHero, typeHero);
                if (heroType == null)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    heroes.Add(heroType);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int heroesPower = 0;
            if (heroes.Count > 0)
            {
                heroesPower = heroes.Sum(h => h.Power);
                foreach (BaseHero hero in heroes)
                {
                    Console.WriteLine(hero.CastAbility());
                }
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

            
        }

        // Use the Factory Design pattern to instantiate the classes
        // https://www.dotnettricks.com/learn/designpatterns/factory-method-design-pattern-dotnet
        // https://www.c-sharpcorner.com/article/factory-design-pattern-in-c-sharp/

        public static BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero ObjectType = null;

            if (heroType == "Druid")
            {
                ObjectType = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                ObjectType = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                ObjectType = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                ObjectType = new Warrior(heroName);
            }

                return ObjectType;
        }

    }
}