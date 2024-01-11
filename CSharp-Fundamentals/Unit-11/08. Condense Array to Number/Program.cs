using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*    int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int numbersArrayLenght = numbersArray.Length;

                int[] tempArray = new int[numbersArrayLenght];
                int[] condenzedArray = new int[numbersArrayLenght];

                int condenzedArrayLight = condenzedArray.Length;

                tempArray = numbersArray;
                condenzedArray = tempArray;
                int count = tempArray.Length;
                while (count >= 1)
                {
                    for (int i = 0; i < count - 1; i++)
                    {
                        condenzedArray[i] = tempArray[i] + tempArray[i+1];   
                    }
                    tempArray = condenzedArray;
                    count--;
                }
                Console.WriteLine(condenzedArray[0]);
            */
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (array.Length > 1)
            {
                int[] condensed = new int[array.Length - 1];
                for (int i = 0; i < condensed.Length; i++)
                {
                    condensed[i] = array[i] + array[i + 1];
                }

                array = condensed;
            }

            Console.WriteLine(array[0]);
        }

    }
}
