namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (var inputFS = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] bufferRead = new byte[1024];

                using (var outputFS = new FileStream(outputFilePath, FileMode.Create))
                {
                    
                    int byteRead;
                    while ((byteRead = inputFS.Read(bufferRead)) != 0)
                    {
                        outputFS.Write(bufferRead, 0, byteRead);

                    }

                }
            }
        }
    }
}
