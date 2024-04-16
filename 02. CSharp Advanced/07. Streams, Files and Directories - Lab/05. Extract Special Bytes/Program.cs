namespace ExtractSpecialBytes
{
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
            var binaryReader = new StreamReader(bytesFilePath);
            var searchingBytes = new List<byte>();
            using (binaryReader)
            {
                string currRow = string.Empty;
                while ((currRow = binaryReader.ReadLine())!= null)
                {
                    searchingBytes.Add(byte.Parse(currRow));
                }

            }

            var binaryBytes = new FileStream(binaryFilePath, FileMode.Open);
            var occurences = new List<byte>();
            using (binaryBytes)
            {
                byte[] buffer = new byte[binaryBytes.Length];
                binaryBytes.Read(buffer, 0, buffer.Length);
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (searchingBytes.Contains(buffer[i]))
                    {
                        occurences.Add(buffer[i]);
                    }
                }
            }

            var output = new FileStream(outputPath, FileMode.Create);
            using (output)
            {
                output.Write(occurences.ToArray(),0,occurences.Count);
            }
        }
    }
}