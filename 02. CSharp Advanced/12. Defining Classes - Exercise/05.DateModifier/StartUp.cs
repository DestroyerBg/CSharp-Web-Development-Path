using System;
namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            int difference = DateModifier.CalculateDifference(date1, date2);
            Console.WriteLine(difference);
        }
    }
}