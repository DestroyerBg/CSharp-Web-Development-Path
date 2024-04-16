using System.Text;

namespace Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numberOne = Console.ReadLine();
            string numberTwo = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            if (numberOne == "0" || numberTwo == "0")
            {
                Console.WriteLine($"0");
                return;
            }

            for (int i = numberOne.Length - 1; i >= 0; i--)
            {
                int currNum = int.Parse(numberOne[i].ToString());
                int multiplayer = int.Parse(numberTwo);
                int result = currNum * multiplayer + carry;
                if (result>10)
                {
                    carry = result / 10;
                    result %= 10;
                    
                    
                }
                else
                {
                    carry = 0;
                }
                sb.Insert(0, result);
            }

            if (carry>0)
            {
                sb.Insert(0,carry);
            }
            Console.WriteLine($"{sb}");
        }
    }
}