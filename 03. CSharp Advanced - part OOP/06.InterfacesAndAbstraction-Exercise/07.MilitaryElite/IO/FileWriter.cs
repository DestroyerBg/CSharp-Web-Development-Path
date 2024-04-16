using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.IO.Interfaces
{
    public class FileWriter : IFileWriter
    {
        private string outputFilePath = @"../../../output.txt";
        public void WriteLine(string line)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(line);
            }
        }
    }
}
