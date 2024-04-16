namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equal = new EqualityScale<int>(2, 3);
            Console.WriteLine(equal.AreEqual());
        }
    }
}