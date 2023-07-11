namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
                Directory.CreateDirectory(outputPath);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
            }
            
            foreach (var file in Directory.GetFiles(inputPath))
            {
                FileInfo fileInfo = new FileInfo(file);
                string outputFile = outputPath + "/" + fileInfo.Name;
                File.Copy(file, outputFile);
            }
        }
    }
}
