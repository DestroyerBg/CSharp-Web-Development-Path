namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] names = Directory.GetFiles(inputPath);
           
            foreach (string name in names)
            {
                string fileName = Path.GetFileName(name);
                string destPath = Path.Combine(outputPath, name);
                File.Copy(name, destPath,true);
            }

            
        }
    }
}