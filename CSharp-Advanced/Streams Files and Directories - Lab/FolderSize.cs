namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            string[] allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            long sum = 0;
            foreach (string file in allFiles) 
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }
            decimal result = sum * 1M / 1024;

            using (var outputFS = new StreamWriter(outputFilePath))
            {
                outputFS.Write($"{result} KB");
            }

        }
    }
}
