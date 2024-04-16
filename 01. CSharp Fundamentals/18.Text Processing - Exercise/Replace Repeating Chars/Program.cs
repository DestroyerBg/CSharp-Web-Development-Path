using System.Text;

namespace Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < text.Length; i++)
            {
                if (i + 1 >= text.Length)
                {
                    sb.Append(text[text.Length-1]);
                    break;
                }
                else if (text[i] != text[i+1])
                {
                    sb.Append(text[i]);
                }
            }

            Console.WriteLine($"{sb}");
        }
    }
}