using System.Text;

namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            var allFiles = new Dictionary<string, List<FileInfo>>();
            string[] allFilesNames = Directory.GetFiles(inputFolderPath);
            foreach (var file in allFilesNames)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (!allFiles.ContainsKey(fileInfo.Extension))
                {
                    allFiles.Add(fileInfo.Extension,new List<FileInfo>());
                }
                allFiles[fileInfo.Extension].Add(fileInfo);
            }
            StringBuilder result = new StringBuilder();
            var orderedFiles = allFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
            foreach (var file in orderedFiles)
            {
                result.AppendLine(file.Key);
                foreach (var subFile in file.Value)
                {
                    result.AppendLine($"--{subFile}.{file.Key} - {subFile.Length}kb");
                }
            }
            
            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        { 
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(outputFilePath, textContent);
        }
    }
}