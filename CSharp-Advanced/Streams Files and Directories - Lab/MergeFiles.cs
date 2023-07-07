namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var firstFile = new StreamReader(firstInputFilePath))
            {
                using (var secondFile = new StreamReader(secondInputFilePath))
                {
                    using (var outputFile = new StreamWriter(outputFilePath))
                    {
                        while (!firstFile.EndOfStream && !secondFile.EndOfStream )
                        {
                            string lineOne = firstFile.ReadLine();
                            outputFile.WriteLine(lineOne);
                            string lineTwo = secondFile.ReadLine();
                            outputFile.WriteLine(lineTwo);
                        }
                    }
                }
            }
        }
    }
}
