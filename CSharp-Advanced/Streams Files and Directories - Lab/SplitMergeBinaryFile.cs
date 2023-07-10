namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFS = new FileStream(sourceFilePath, FileMode.Open))
            {
                int firstBufferSize = 0;
                int secondBufferSize = 0;   
                if (sourceFS.Length % 2 != 0)
                {
                    firstBufferSize = ((int)sourceFS.Length / 2) + 1;
                    secondBufferSize = ((int)sourceFS.Length / 2);
                }
                else
                {
                    firstBufferSize = (int)sourceFS.Length / 2;
                    secondBufferSize = firstBufferSize;
                }

                byte[] firstPart = new byte[firstBufferSize];
                byte[] secondPart = new byte[secondBufferSize];

                sourceFS.Read(firstPart, 0, firstPart.Length);
                sourceFS.Read(secondPart, 0, secondPart.Length);

                using (var partOneFS = new FileStream(partOneFilePath, FileMode.Create))
                {
                    partOneFS.Write(firstPart);
                }

                using (var partTwoFS = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    partTwoFS.Write(secondPart);
                }


            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var joinedFS = new FileStream(joinedFilePath, FileMode.Create))
            {
                using (var partOneFS = new FileStream(partOneFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partOneFS.Length];
                    partOneFS.Read(buffer, 0, buffer.Length);
                    joinedFS.Write(buffer);
                }

                using (var partTwoFS = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    byte[] buffer = new byte[partTwoFS.Length];
                    partTwoFS.Read(buffer, 0, buffer.Length);
                    joinedFS.Write(buffer);
                }


            }
        }
    }
}