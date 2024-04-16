namespace Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string result=string.Empty;
                for (int i = input.Length-1; i >= 0; i--)
                {
                    result += input[i];
                }

                Console.WriteLine($"{input} = {result}");
            }
            
        }
    }
}