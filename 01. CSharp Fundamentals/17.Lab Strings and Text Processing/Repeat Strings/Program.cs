namespace Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console
                .ReadLine()
                .Split()
                .ToArray();
            string result = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                for (int k = 0; k < text[i].Length; k++)
                {
                    result += text[i];
                }
            }

            Console.WriteLine($"{result}");
        }
    }
}