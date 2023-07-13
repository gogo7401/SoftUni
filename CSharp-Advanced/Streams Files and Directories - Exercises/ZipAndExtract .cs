namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            FileInfo fileInfo = new FileInfo(inputFilePath);
            string sourceDir = fileInfo.DirectoryName + "/temp";
            if (Directory.Exists(sourceDir))
            {
                Directory.Delete(sourceDir, true);
                Directory.CreateDirectory(sourceDir);
            }
            else
            {
                Directory.CreateDirectory(sourceDir);
            }
            string sourceFile = sourceDir + "/extracted.png";
            File.Copy(inputFilePath, sourceFile, true);


            ZipFile.CreateFromDirectory(sourceDir, zipArchiveFilePath, CompressionLevel.Fastest, false);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            // extracted.png
            FileInfo fileInfo = new FileInfo(outputFilePath);
            string destinDir = fileInfo.DirectoryName;
            ZipFile.ExtractToDirectory(zipArchiveFilePath, destinDir, true);

        }
    }
}
