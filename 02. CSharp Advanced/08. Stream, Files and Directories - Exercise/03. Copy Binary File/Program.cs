namespace CopyBinaryFile
{
    using System;

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
            byte[] bytes = null;
            using (var copy = new FileStream(inputFilePath, FileMode.Open))
            {
                bytes = new byte[copy.Length];
                copy.Read(bytes, 0, bytes.Length);
            }

            using (var paste = new FileStream(outputFilePath, FileMode.Create))
            {
                paste.Write(bytes,0,bytes.Length);
            }
            
        }
    }
}