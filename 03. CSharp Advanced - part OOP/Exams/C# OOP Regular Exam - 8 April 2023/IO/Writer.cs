using System.IO;

namespace RobotService.IO
{
    using RobotService.IO.Contracts;
    using System;
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
