namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string[] expression = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
           Stack<string> stack = new Stack<string>();
           int sum = 0;
           for (int i = expression.Length-1; i >= 0; i--)
           {
                stack.Push(expression[i]);
           }

           sum += int.Parse(stack.Pop());
           while (stack.Count>0)
           {
               string operation = stack.Pop();
               int number= int.Parse(stack.Pop());
               if (operation=="-")
               {
                   sum-=number;
               }
               else if (operation=="+")
               {
                   sum += number;
               }
           }

           Console.WriteLine(sum);

        }
    }
}