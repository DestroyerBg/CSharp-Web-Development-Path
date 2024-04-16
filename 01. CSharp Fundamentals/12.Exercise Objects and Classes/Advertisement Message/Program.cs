using System.Net.Http.Headers;

namespace Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            string[] phrases = { "Excellent product.", "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
                 };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", 
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random random= new Random();
            for (int i = 0; i < numberOfMessages; i++)
            {
                int generatedPhrase = random.Next(phrases.Length);
                int generatedEvent=random.Next(events.Length);
                int generatedAuthors=random.Next(authors.Length);
                int generatedCity=random.Next(cities.Length);
                Console.WriteLine($"{phrases[generatedPhrase]} {events[generatedPhrase]} {authors[generatedAuthors]} – {cities[generatedCity]}.");

            }
        }
    }
}