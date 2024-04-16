namespace Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            List<char> digits = new List<char>();
            List<char> letters = new List<char>();
            List<char> others = new List<char>();
            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];
                bool isDigit= char.IsDigit(currChar);
                if (isDigit==true)
                {
                    digits.Add(currChar);
                    continue;
                }
                bool isLetter=char.IsLetter(currChar);
                if (isLetter==true)
                {
                    letters.Add(currChar);
                    continue;
                }
                others.Add(currChar);
                
            }

            Console.WriteLine(string.Join("",digits));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", others));
        }
    }
}