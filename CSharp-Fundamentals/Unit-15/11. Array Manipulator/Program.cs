///*
using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string command = "";
            int[] newArray = arrayLine;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command.Contains("exchange"))
                {
                    if ((int.Parse(command.Substring(9)) >= newArray.Length) || (int.Parse(command.Substring(9)) < 0))
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                        
                    }
                    newArray = Exchange(command.Substring(9), newArray);
                }
                else if (command.Contains("max even"))
                {
                    int maxEven = GetMaxEven(newArray);
                    if (maxEven >= 0)
                    {
                        Console.WriteLine(maxEven);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command.Contains("max odd"))
                {
                    int maxOdd = GetMaxOdd(newArray);
                    if (maxOdd >= 0)
                    {
                        Console.WriteLine(maxOdd);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command.Contains("min even"))
                {
                    int minEven = GetMinEven(newArray);
                    if (minEven >= 0)
                    {
                        Console.WriteLine(minEven);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command.Contains("min odd"))
                {
                    int minOdd = GetMinOdd(newArray);
                    if (minOdd >= 0)
                    {
                        Console.WriteLine(minOdd);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (command.Contains("first"))
                {
                    string[] firstCount = command.Split(' ').ToArray();
                    if ((int.Parse(firstCount[1]) <= newArray.Length) && (int.Parse(firstCount[1]) > 0))
                    {
                        string pattern = "";
                        if (firstCount[2] == "odd")
                        {
                            pattern = GetFirstCountOdd(firstCount[1], newArray);
                        }
                        else if (firstCount[2] == "even")
                        {
                            pattern = GetFirstCountEven(firstCount[1], newArray);
                        }
                        
                        Console.WriteLine("["+pattern+"]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }
                else if (command.Contains("last"))
                {
                    string[] lastCount = command.Split(' ').ToArray();
                    if ((int.Parse(lastCount[1]) <= newArray.Length) && (int.Parse(lastCount[1]) > 0))
                    {
                        string pattern = "";
                        if (lastCount[2] == "odd")
                        {
                            pattern = GetLastCountOdd(lastCount[1], newArray);
                        }
                        else if (lastCount[2] == "even")
                        {
                            pattern = GetLastCountEven(lastCount[1], newArray);
                        }

                        Console.WriteLine("[" + pattern + "]");
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                }

                //Console.Write("[");
                //Console.Write(String.Join(", ", newArray));
                //Console.WriteLine("]");
            }
            Console.Write("[");
            Console.Write(String.Join(", ", newArray));
            Console.WriteLine("]");
        }

        private static string GetLastCountEven(string countString, int[] newArray)
        {
            int count = int.Parse(countString);
            int[] tempArray = new int[count];
            string result = "";
            int tempArrayCount = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] % 2 == 0)
                {
                    tempArray[tempArrayCount] = newArray[i];
                    tempArrayCount++;
                }
            }
            if (tempArrayCount > count)
            {
                for (int i = (tempArrayCount-count); i <= tempArrayCount-1; i++)
                {
                    result += tempArray[i] + ", ";
                }
            }
            else if (tempArrayCount <= count)
            {
                for (int i = 0; i <= tempArrayCount-1; i++)
                {
                    result += tempArray[i] + ", ";
                }
            }
            if (tempArrayCount <= 0)
            {
                result = "";
            }
            else
            {
                result = result.Substring(0, result.Length-2);
            }


            return result;
        }

        private static string GetLastCountOdd(string countString, int[] newArray)
        {
            int count = int.Parse(countString);
            int[] tempArray = new int[count];
            string result = "";
            int tempArrayCount = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] % 2 != 0)
                {
                    tempArray[tempArrayCount] = newArray[i];
                    tempArrayCount++;
                }
            }
            if (tempArrayCount > count)
            {
                for (int i = (tempArrayCount - count); i <= tempArrayCount - 1; i++)
                {
                    result += tempArray[i] + ", ";
                }
            }
            else if (tempArrayCount <= count)
            {
                for (int i = 0; i <= tempArrayCount-1; i++)
                {
                    result += tempArray[i] + ", ";
                }
            }
            if (tempArrayCount <= 0)
            {
                result = "";
            }
            else
            {
                result = result.Substring(0, result.Length - 2);
            }


            return result;
        }

        private static string GetFirstCountEven(string countString, int[] newArray)
        {
            int count = int.Parse(countString);
            int currentCount = 0;
            string result = "";
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] % 2 == 0)
                {
                    currentCount++;
                    if (currentCount <= count)
                    {
                        result += newArray[i] + ", ";
                    }
                    else
                    {
                        currentCount--;
                        break;
                    }
                }
            }
            if (currentCount <= 0)
            {
                result = "";
            }
            else
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }

        private static string GetFirstCountOdd(string countString, int[] newArray)
        {
            int count = int.Parse(countString);
            int currentCount = 0;
            string result = "";
            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] % 2 != 0)
                {
                    currentCount++;
                    if (currentCount <= count)
                    {
                        result += newArray[i] + ", ";
                    }
                    else
                    {
                        currentCount--;
                        break;
                    }
                }
            }
            if (currentCount <= 0)
            {
                result = "";
            }
            else
            {
                result = result.Substring(0, result.Length - 2);
            }

            return result;
        }

        private static int GetMaxOdd(int[] newArray)
        {
            int result = -1;
            int maxOdd = int.MinValue;
            for (int i = 0; i < newArray.Length; i++)
            {
                if ((newArray[i] >= maxOdd ) && (newArray[i] % 2 != 0))
                {
                    result = i;
                    maxOdd = newArray[i];
                }
            }

            return result;
        }

        private static int GetMinOdd(int[] newArray)
        {
            int result = -1;
            int minOdd = int.MaxValue;
            for (int i = 0; i < newArray.Length; i++)
            {
                if ((newArray[i] <= minOdd) && (newArray[i] % 2 != 0))
                {
                    result = i;
                    minOdd = newArray[i];
                }
            }

            return result;
        }

        private static int GetMaxEven(int[] newArray)
        {
            int result = -1;
            int maxEven = int.MinValue;
            for (int i = 0; i < newArray.Length; i++)
            {
                if ((newArray[i] >= maxEven) && (newArray[i] % 2 == 0))
                {
                    result = i;
                    maxEven = newArray[i];
                }
            }

            return result;
        }

        private static int GetMinEven(int[] newArray)
        {
            int result = -1;
            int minEven = int.MaxValue;
            for (int i = 0; i < newArray.Length; i++)
            {
                if ((newArray[i] <= minEven) && (newArray[i] % 2 == 0))
                {
                    result = i;
                    minEven = newArray[i];
                }
            }

            return result;
        }

        private static int[] Exchange(string exchangeIndex, int[] newArray)
        {
            int[] tempArray = new int[newArray.Length];
            int splitIntex = int.Parse(exchangeIndex);
            int tempArrayIndex = 0;
            if (splitIntex + 1 >= newArray.Length)
            {
                splitIntex = 0;
            }
            else
            {
               splitIntex += 1;
            }
            for (int i = splitIntex; i < newArray.Length; i++)
            {
                tempArray[tempArrayIndex] = newArray[i];
                tempArrayIndex++;
            }
            for (int i = 0; i < splitIntex; i++)
            {
                tempArray[tempArrayIndex] = newArray[i];
                tempArrayIndex++;
            }


            return tempArray;
        }
    }
}
//*/










/*
using System;
using System.Linq;

namespace P11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(' ');

                string cmdType = cmdArgs[0];
                if (cmdType == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArgs[1]);

                    if (exchangeIndex < 0 || exchangeIndex >= numbers.Length)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    numbers = ExchangeArrayParts(numbers, exchangeIndex);
                }
                else if (cmdType == "max" || cmdType == "min")
                {
                    string oddOrEven = cmdArgs[1];

                    int index;
                    if (cmdType == "max")
                    {
                        index = MaxElementOfTypeIndex(numbers, oddOrEven);
                    }
                    else
                    {
                        index = MinElementOfTypeIndex(numbers, oddOrEven);
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (cmdType == "first" || cmdType == "last")
                {
                    int count = int.Parse(cmdArgs[1]);
                    string oddOrEven = cmdArgs[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (cmdType == "first")
                    {
                        PrintFirstElementsOfType(numbers, count, oddOrEven);
                    }
                    else
                    {
                        PrintLastElementsOfType(numbers, count, oddOrEven);
                    }
                }
            }

            Console.WriteLine(ArrayToStringFormat(numbers, numbers.Length));
        }

        static int[] ExchangeArrayParts(int[] numbers, int index)
        {
            int[] exchangedNumbers = new int[numbers.Length];
            int exchangedNumbersIndex = 0;

            for (int i = index + 1; i < numbers.Length; i++)
            {
                exchangedNumbers[exchangedNumbersIndex] = numbers[i];
                exchangedNumbersIndex++;
            }

            for (int i = 0; i <= index; i++)
            {
                exchangedNumbers[exchangedNumbersIndex] = numbers[i];
                exchangedNumbersIndex++;
            }

            return exchangedNumbers;
        }

        static int MaxElementOfTypeIndex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int maxValue = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }

        static int MinElementOfTypeIndex(int[] numbers, string oddOrEven)
        {
            int index = -1;
            int minValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }

        static void PrintFirstElementsOfType(int[] numbers, int count, string oddOrEven)
        {
            int[] firstElements = new int[count];
            int firstElementsIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currNum;
                        firstElementsIndex++;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && firstElementsIndex < count)
                    {
                        firstElements[firstElementsIndex] = currNum;
                        firstElementsIndex++;
                    }
                }
            }

            Console.WriteLine(ArrayToStringFormat(firstElements, firstElementsIndex));
        }

        static void PrintLastElementsOfType(int[] numbers, int count, string oddOrEven)
        {
            int[] lastElements = new int[count];
            int lastElementsIndex = 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int currNum = numbers[i];

                if (oddOrEven == "even")
                {
                    if (currNum % 2 == 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currNum;
                        lastElementsIndex++;
                    }
                }
                else if (oddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && lastElementsIndex < count)
                    {
                        lastElements[lastElementsIndex] = currNum;
                        lastElementsIndex++;
                    }
                }
            }

            int[] reverseArray = new int[lastElementsIndex];
            int reverseArrayIndex = 0;
            for (int i = lastElementsIndex - 1; i >= 0; i--)
            {
                reverseArray[reverseArrayIndex] = lastElements[i];
                reverseArrayIndex++;
            }

            Console.WriteLine(ArrayToStringFormat(reverseArray, reverseArrayIndex));
        }

        static string ArrayToStringFormat(int[] arr, int elementsCount)
        {
            string output = string.Empty;
            output += "[";

            for (int i = 0; i < elementsCount; i++)
            {
                if (i == elementsCount - 1)
                {
                    output += $"{arr[i]}";
                }
                else
                {
                    output += $"{arr[i]}, ";
                }
            }

            output += "]";

            return output;
        }
    }
}
*/