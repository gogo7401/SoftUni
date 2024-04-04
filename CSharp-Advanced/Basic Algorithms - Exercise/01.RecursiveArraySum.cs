namespace _1.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
 
            Console.WriteLine(Sum(arr, 0));
        }


        private static int Sum(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            int sum = array[index] + Sum(array, index + 1);

            return sum;
        }
    }
}
