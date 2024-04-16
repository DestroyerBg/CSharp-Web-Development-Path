using System.ComponentModel.Design;

namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            List<string> inputData = new List<string>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                inputData = Console
                    .ReadLine()
                    .Split("_")
                    .ToList();
                
                Song song = new Song();
                string typeList = inputData[0];
                string name = inputData[1];
                string time = inputData[2];
                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;
                songs.Add(song);

            }

            string typeToPrint = Console.ReadLine();
            if (typeToPrint == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> songAfterFilter = songs.Where(x => x.TypeList == typeToPrint).ToList();
                foreach (Song song in songAfterFilter)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }

        public class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}