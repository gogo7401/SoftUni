namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackValue = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(clothesValue);

            int passedClothesValue = 0;
            int curreenClothesValue = 0;
            int rackCount = 1;

            while (box.Count > 0)
            {
                curreenClothesValue = box.Peek();
                if ((curreenClothesValue + passedClothesValue) > rackValue)
                {
                    rackCount++;
                    passedClothesValue = 0;
                }
                else if ((curreenClothesValue + passedClothesValue) == rackValue)
                {
                    if (box.Count != 1)
                    {
                        rackCount++;
                        passedClothesValue = 0;
                    }
                    box.Pop();

                }
                else if ((curreenClothesValue + passedClothesValue) < rackValue)
                {
                    passedClothesValue += curreenClothesValue;
                    box.Pop();
                }
                
            }

            Console.WriteLine(rackCount);
        }
    }
}