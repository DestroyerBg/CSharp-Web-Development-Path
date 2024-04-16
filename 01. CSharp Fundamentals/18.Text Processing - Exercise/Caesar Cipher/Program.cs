using System.Text;

namespace Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                int index = text[i];
                sb.Append((char)(index+3));


            }

            Console.WriteLine($"{sb}");
        }
    }
}