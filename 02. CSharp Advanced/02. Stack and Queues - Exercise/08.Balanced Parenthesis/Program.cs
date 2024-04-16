namespace _08.Balanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var parenthess = new Stack<char>();
            foreach (var currChar in input)
            {
                if (currChar == '(' || currChar == '[' || currChar == '{')
                {
                    parenthess.Push(currChar);
                    continue;
                }

                if (parenthess.Count==0)
                {
                    parenthess.Push(currChar);
                    break;
                }
                if ((currChar == ')' && parenthess.Peek() == '(') ||
                    (currChar == ']' && parenthess.Peek() == '[') ||
                    (currChar == '}' && parenthess.Peek() == '{'))
                {
                    parenthess.Pop();
                }
            }

            if (parenthess.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else 
            {
                Console.WriteLine("NO");
            }

        }
    }
}