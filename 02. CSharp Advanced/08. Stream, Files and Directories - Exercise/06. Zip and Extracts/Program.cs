using System.IO.Compression;

namespace ZipAndExtract
{
    using System;
    using System.IO;
    using static System.Net.Mime.MediaTypeNames;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string zipArchiveFilePath = @"..\..\..\archive.zip";
            string outputFilePath = @"..\..\..\extracted.png";
            string fileName = Path.GetFileName(inputFilePath);
            ZipFileToArchive(inputFilePath, zipArchiveFilePath);
            ExtractFileFromArchive(zipArchiveFilePath,fileName,outputFilePath);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (var zip =  ZipFile.Open(zipArchiveFilePath,ZipArchiveMode.Create))
            {
                string pathFileName = Path.GetFileName(inputFilePath);
                zip.CreateEntryFromFile(inputFilePath,pathFileName);
            }
        }
        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (var unzip = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry extract = unzip.GetEntry(fileName);
                extract.ExtractToFile(outputFilePath);
            }
        }

    }
}

