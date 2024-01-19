using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*    int linesCount = int.Parse(Console.ReadLine());
                string[] lines = new string[linesCount];
                string[] sampleText = new string[linesCount];

                string line = Console.ReadLine();

                int sampleLineCurrent = 0, maxCountOnesInSample = 0, countOnes = 0;
                int indexOnesInSample = 0, indexCurrent = 0, sumOnesInSample = 0, sumCurrent = 0;
                int index = 0, maxCount = 0, sum = 0, sampleLine = 0;

                while (line != "Clone them!")
                {
                    lines = line.Split('!', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    sampleLineCurrent++;
                    maxCountOnesInSample = 0;
                    indexOnesInSample = linesCount;
                    sumOnesInSample = 0;
                    sumCurrent = 0;
                    countOnes = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {

                        if (lines[i] == "1")
                        {
                            sumCurrent++;
                            countOnes++;
                            if (countOnes == 1) { indexCurrent = i; }
                        }
                        else
                        {
                            countOnes = 0;
                            indexCurrent = 0;

                        }
                        if (maxCountOnesInSample < countOnes)
                        {
                            maxCountOnesInSample = countOnes;
                            indexOnesInSample = indexCurrent;

                        }
                    }
                    sumOnesInSample = sumCurrent;
                    if (maxCount < maxCountOnesInSample)
                    {
                        maxCount = maxCountOnesInSample;
                        index = indexOnesInSample;
                        sum = sumOnesInSample;
                        sampleText = lines;
                        sampleLine = sampleLineCurrent;
                    }
                    if (maxCount == maxCountOnesInSample && index > indexOnesInSample)
                    {
                        maxCount = maxCountOnesInSample;
                        index = indexOnesInSample;
                        sum = sumOnesInSample;
                        sampleText = lines;
                        sampleLine = sampleLineCurrent;
                    }
                    if (maxCount == maxCountOnesInSample && index == indexOnesInSample && sum < sumOnesInSample)
                    {
                        maxCount = maxCountOnesInSample;
                        index = indexOnesInSample;
                        sum = sumOnesInSample;
                        sampleText = lines;
                        sampleLine = sampleLineCurrent;
                    }

                    line = Console.ReadLine();
                }

                if (maxCount>0)
                {
                    Console.WriteLine($"Best DNA sample {sampleLine} with sum: {sum}.");
                    Console.WriteLine(String.Join(" ", sampleText));

                }
            */
            int dnaLength = int.Parse(Console.ReadLine());

            int[] bestSample = new int[dnaLength];
            int leftmostIndex = dnaLength;
            int bestSampleSequenseLenght = 0;
            int bestSampleSum = 0;
            int bestSampleNumber = 1;

            string command = Console.ReadLine();
            int sampleNum = 0;

            while (command != "Clone them!")
            {
                int[] currentSample = command.Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sampleNum++;

                int currentSequenceLenght = 0;
                int previousSequenceLenght = 0;
                int currentLongestSequence = 0;

                int leftmostIndexInCurrentArray = dnaLength;

                int currentSampleSum = 0;

                for (int i = 0; i < currentSample.Length; i++)
                {
                    if (currentSample[i] == 1)
                    {
                        currentSequenceLenght++;
                        currentSampleSum++;
                    }
                    else
                    {
                        previousSequenceLenght = currentSequenceLenght;
                        currentSequenceLenght = 0;
                    }

                    if (currentSequenceLenght > previousSequenceLenght)
                    {
                        currentLongestSequence = currentSequenceLenght;
                        leftmostIndexInCurrentArray = i - currentSequenceLenght + 1;
                    }
                }

                if (currentLongestSequence > bestSampleSequenseLenght)
                {
                    bestSampleSequenseLenght = currentLongestSequence;
                    leftmostIndex = leftmostIndexInCurrentArray;
                    bestSample = currentSample;
                    bestSampleNumber = sampleNum;
                    bestSampleSum = currentSampleSum;
                }
                else if (currentLongestSequence == bestSampleSequenseLenght)
                {
                    if (leftmostIndexInCurrentArray < leftmostIndex)
                    {
                        leftmostIndex = leftmostIndexInCurrentArray;
                        bestSampleSum = currentSampleSum;
                        bestSample = currentSample;
                        bestSampleNumber = sampleNum;
                    }
                    else if (leftmostIndex == leftmostIndexInCurrentArray)
                    {
                        if (currentSampleSum > bestSampleSum)
                        {
                            bestSampleSum = currentSampleSum;
                            bestSample = currentSample;
                            bestSampleNumber = sampleNum;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleNumber} with sum: {bestSampleSum}.");
            Console.WriteLine(string.Join(" ", bestSample));
        }
    }
}
