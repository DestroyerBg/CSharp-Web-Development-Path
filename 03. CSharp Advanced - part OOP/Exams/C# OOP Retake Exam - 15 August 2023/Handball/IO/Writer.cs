using System.IO;

namespace Handball.IO
{
    using Handball.IO.Contracts;
    using System;
    public class Writer : IWriter
    {
        string outputFilePath = @"../../../output.txt";
        public Writer()
        {
            File.Delete(outputFilePath);
        }
        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            using (StreamWriter stream = new StreamWriter(outputFilePath,true))
            {
                stream.WriteLine(message);
            }
        }
    }
}
