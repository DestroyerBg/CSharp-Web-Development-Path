using System;
using System.Text;

namespace String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text=Console.ReadLine();
            StringBuilder sb= new StringBuilder();
            int strength = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char currChar= text[i];
                if (currChar == '>')
                {
                    strength += int.Parse(text[i + 1].ToString());
                    sb.Append(currChar);
                }
                else if (strength==0)
                {
                    sb.Append(currChar);
                }
                else
                {
                    strength--;
                }
            }

            Console.WriteLine($"{sb}");
        }
    }
}