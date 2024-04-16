namespace SplitMergeBinaryFile
{
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
            var reader = new FileStream(sourceFilePath, FileMode.Open);
            using (reader)
            {
                byte[] partOne = new byte[(reader.Length + 1) / 2];
                reader.Read(partOne,0,partOne.Length);
                byte[] partTwo = new byte[reader.Length / 2];
                reader.Read(partTwo, 0, partTwo.Length);
                using (var writerPartOne = new FileStream(partOneFilePath,FileMode.Create))
                {
                    writerPartOne.Write(partOne,0,partOne.Length);
                }
                using (var writerPartTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    writerPartTwo.Write(partTwo, 0, partTwo.Length);
                }

            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var mergeFile = new FileStream(joinedFilePath,FileMode.Create))
            {
                byte[] firstPart = null;
                using (var firstWriter = new FileStream(partOneFilePath,FileMode.Open))
                {
                    firstPart = new byte[firstWriter.Length];
                    mergeFile.Write(firstPart);
                }

                byte[] secondPart = null;
                using (var secondWriter = new FileStream(partTwoFilePath,FileMode.Open))
                {
                    secondPart = new byte[secondWriter.Length];
                    mergeFile.Write(secondPart,0, (int)secondWriter.Length);
                }
            }

        }
    }
}