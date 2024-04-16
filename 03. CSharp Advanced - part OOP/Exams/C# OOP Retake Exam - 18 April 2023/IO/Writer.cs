using EDriveRent.IO.Contracts;
using System;
using System.IO;

namespace EDriveRent.IO
{
    public class Writer : IWriter
    {
        private string outputFilePath = @"../../../output.txt";

        public Writer()
        {
            File.Delete(outputFilePath);
        }
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message)
        { 
            Console.WriteLine(message);
            using (var stream = new StreamWriter(outputFilePath,true))
            {
                stream.WriteLine(message);
            }
        }
    }
}
