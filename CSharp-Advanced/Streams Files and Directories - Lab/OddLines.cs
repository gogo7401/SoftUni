namespace OddLines
{
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (var inputFS = new StreamReader(inputFilePath))
            {
                using (var outputFS = new StreamWriter(outputFilePath))
                {
                    int count = 0;
                    while (true)
                    {
                        string line = inputFS.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        if (count % 2 != 0)
                        {

                            outputFS.WriteLine(line);

                        }
                        count++;

                    }
                }
            }
        }
    }
}
