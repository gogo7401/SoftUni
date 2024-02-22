using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine()
                .Split(' ')
                .ToList();

            while (true)
            {
                string[] manipulation = Console.ReadLine().Split();
                if (manipulation[0] == "3:1")
                {
                    Console.WriteLine(string.Join(" ", inputList));
                    break;

                }                                    // Ivo Johny Tony Bony Mony
                else if (manipulation[0] == "merge") // •	merge {startIndex} {endIndex}  // merge 0 3
                {
                    int startIndex = int.Parse(manipulation[1]);
                    int endIndex = int.Parse(manipulation[2]);
                    string temp = "";
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if ((endIndex) >= inputList.Count)
                    {
                        endIndex = (inputList.Count -1);
                    }
                    if (startIndex >=0 && startIndex <= inputList.Count-1 && endIndex >= 0 && endIndex <= inputList.Count-1 && endIndex > startIndex)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            temp += inputList[i];
                        }
                        inputList.Insert(startIndex, temp);
                        int removeCount = (endIndex - startIndex + 1);

                        inputList.RemoveRange(startIndex + 1, removeCount);
                    }  // 0 1 2 3 4 5 6 7 8 9 
                    
                }
                else if (manipulation[0] == "divide")
                {
                    int index = int.Parse(manipulation[1]);
                    int partitions = int.Parse(manipulation[2]);
                    //if (index < 0 || index >= inputList.Count)
                    //{
                    //    continue;
                    //}
                    int partitionsLenght = (inputList[index].Length / partitions);
                    int last = 0;
                    if (inputList[index].Length % partitions == 0 )
                    {
                        last = partitionsLenght;
                    }
                    else
                    {
                        last = partitionsLenght + (inputList[index].Length % partitions);
                    }
                    string tempString = inputList[index];
                    inputList.RemoveAt(index);
                    for (int i = 1; i <= partitions; i++)
                    {
                        if (i != partitions)
                        {
                            inputList.Insert(index-1+i, tempString.Substring((i-1)*partitionsLenght,partitionsLenght));
                        }
                        else
                        {
                            inputList.Insert(index - 1 + i, tempString.Substring((i - 1) * partitionsLenght, last));
                        }
                    }

                }
            }
        }
    }
}
