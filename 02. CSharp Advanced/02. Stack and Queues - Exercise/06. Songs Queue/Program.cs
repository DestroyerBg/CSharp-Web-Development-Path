namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var songPlaylist = new Queue<string>
            (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (songPlaylist.Count>0)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = input[0];
                if (instruction=="Play")
                {
                    songPlaylist.Dequeue();
                }
                else if (instruction=="Add")
                {
                    string songName = string.Join(" ", input.Skip(1));
                    if (!songPlaylist.Contains(songName))
                    {
                        songPlaylist.Enqueue(songName);
                        continue;
                    }

                    Console.WriteLine($"{songName} is already contained!");
                }
                else if (instruction=="Show")
                {
                    Console.WriteLine(string.Join(", ", songPlaylist));
                }
            }

            Console.WriteLine("No more songs!");

        }
    }
}