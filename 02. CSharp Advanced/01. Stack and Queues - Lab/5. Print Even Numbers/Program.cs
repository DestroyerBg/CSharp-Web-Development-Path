namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var num = new Queue<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Console.Write(string.Join(", ", num.Where(x=>x%2==0)));
        }
    }
}