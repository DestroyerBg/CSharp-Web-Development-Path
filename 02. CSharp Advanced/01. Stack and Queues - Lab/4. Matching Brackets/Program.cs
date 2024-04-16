namespace _4._Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            var stackIndex= new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stackIndex.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = stackIndex.Pop();
                    string result = expression.Substring(startIndex, i-startIndex+1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}