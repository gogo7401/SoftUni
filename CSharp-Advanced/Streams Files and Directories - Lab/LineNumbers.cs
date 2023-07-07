namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (var inputFS = new StreamReader(inputFilePath))
            {
                using (var outputFS = new StreamWriter(outputFilePath))
                {
                    int count = 0;
                    while (!inputFS.EndOfStream) 
                    {
                        count++;
                        outputFS.WriteLine($"{count}. {inputFS.ReadLine()}");
                    }
                }

            }


        }
    }
}
