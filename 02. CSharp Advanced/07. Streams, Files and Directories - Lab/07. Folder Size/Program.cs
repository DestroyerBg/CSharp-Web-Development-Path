namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal sum = 0;
            DirectoryInfo getDirectories = new DirectoryInfo(folderPath);
            FileInfo[] files = getDirectories.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                sum += file.Length;
            }

            sum = sum / 1024 / 1024;
           File.WriteAllText(outputFilePath,$"{sum} KB");
        }
    }
}