namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {

            List<string> input = new List<string>(File.ReadLines(inputFilePath));
            int countLetters = 0;
            int countPunctuation = 0;
            Regex regexLetters = new Regex(@"\w");
            Regex regexPunct = new Regex(@"[-.,!?'""]");

            for (int i = 0; i < input.Count; i++)
            {
                countLetters = regexLetters.Matches(input[i]).Count;
                countPunctuation = regexPunct.Matches(input[i]).Count;
                input[i] = $"Line {i+1}: {input[i]} ({countLetters})({countPunctuation})";
            }

            File.WriteAllLines(outputFilePath, input); 
        }
    }
}
