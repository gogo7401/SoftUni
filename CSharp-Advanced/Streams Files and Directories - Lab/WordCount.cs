namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            string inputText = string.Empty;
            var wordList = new List<string>();
            var result = new Dictionary<string, int>();

            string pattern = @"\b\w+";
            Regex regex = new Regex(pattern);

            using (var textFS = new StreamReader(textFilePath))
            {
                inputText = textFS.ReadToEnd();
            }
            MatchCollection textWords = regex.Matches(inputText);

            using (var wordsFS = new StreamReader(wordsFilePath))
            {
                inputText = wordsFS.ReadToEnd();
            }
            wordList = inputText
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var word in wordList)
            {
                int count = 0;
                foreach (var currWord in textWords)
                {
                    if (word.ToUpper() == currWord.ToString().ToUpper())
                    {
                        count++;
                    }
                }
                if (result.ContainsKey(word))
                {
                    result[word] += count;
                }
                else
                {
                    result.Add(word, count);
                }
            }



            using (var outputFS = new StreamWriter(outputFilePath))
            {
                foreach (var item in result.OrderByDescending(x => x.Value))
                {
                    outputFS.WriteLine($"{item.Key} - {item.Value}");
                }
            }



        }
    }
}
