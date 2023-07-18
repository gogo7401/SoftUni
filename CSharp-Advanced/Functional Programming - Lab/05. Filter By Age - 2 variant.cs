namespace _05._Filter_By_Age___2_variant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> list = new List<Person>();

            Func<Person, string, int, bool> filter = (p, c, a) => c == "older" ? p.Age >= a : p.Age < a;

            Action<Person, string> print = (p, f) =>
            {
                switch (f)
                {
                    case "name":
                        Console.WriteLine(p.Name);
                        break;
                    case "age":
                        Console.WriteLine(p.Age);
                        break;
                    case "name age":
                        Console.WriteLine($"{p.Name} - {p.Age}");
                        break;
                }
            };

            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person();
                person.Name = token[0];
                person.Age = int.Parse(token[1]);
                list.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            foreach (Person person in list)
            {
                if (filter(person, condition, age))
                {
                    print(person, format);
                }
            }

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}