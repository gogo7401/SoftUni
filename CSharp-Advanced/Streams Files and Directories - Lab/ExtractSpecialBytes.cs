namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (var imageFS = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (var bytesFS = new FileStream(bytesFilePath, FileMode.Open))
                {
                    byte[] bufferBytes = new byte[bytesFS.Length];
                    byte[] bufferImage = new byte[imageFS.Length];

                    imageFS.Read(bufferImage, 0, bufferImage.Length);
                    bytesFS.Read(bufferBytes, 0, bufferBytes.Length);

                    using (var outputFS = new FileStream(outputPath, FileMode.Create))
                    {

                        for (int i = 0; i < bufferImage.Length; i++)
                        {
                            for (int j = 0; j < bufferBytes.Length; j++)
                            {
                                if (bufferImage[i] == bufferBytes[j])
                                {
                                    //outputFS.WriteByte(bufferImage[i]);
                                    outputFS.Write(new byte[] {bufferImage[i]});
                                }
                            }
                        }
                    }

                }

            }


        }
    }
}
