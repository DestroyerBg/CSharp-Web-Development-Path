namespace Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console
                .ReadLine()
                .Split()
                .ToArray();
            string textOne= data[0];
            string textTwo= data[1];
            int length = Math.Max(textOne.Length, textTwo.Length);
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                if (i<textOne.Length && i<textTwo.Length)
                {
                    result += textOne[i]*textTwo[i];
                }

                else if (i<textOne.Length)
                {
                    result += textOne[i];
                }
                else if (i<textTwo.Length)
                {
                    result += textTwo[i];
                }
            }

            Console.WriteLine($"{result}");
        }
    }
}