namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            string result = string.Empty;
            List<string> lines = new List<string>();
            List<string> output = new List<string>();
            char[] symbols = new char[] { '-', ',', '.', '!', '?' };

            using (var inputFS = new StreamReader(inputFilePath))
            {
                int countLine = 0;
                while (!inputFS.EndOfStream)
                {
                    string line = inputFS.ReadLine();
                    if (countLine % 2 == 0)
                    {
                        lines.Add(line);
                    }
                    countLine++;
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                string replaced = lines[i];

                foreach (char c in symbols)
                {
                    replaced = replaced.ToString().Replace(c, '@');
                }
                lines[i] = replaced;
            }

            foreach (var item in lines)
            {
                string[] words = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                for (int i = words.Length-1; i >= 0; i--)
                {
                    sb.Append(words[i] + " ");
                }
                sb.Remove(sb.Length-1, 1);

                output.Add(sb.ToString());
                //string temp = new string(item.ToCharArray().Reverse().ToArray());
                //output.Add(temp);
            }


            result = string.Join(Environment.NewLine, output);

            return result;
        }
    }
}
