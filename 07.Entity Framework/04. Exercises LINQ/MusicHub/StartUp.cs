using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums.Where(a => a.ProducerId == producerId)
                .Select(a => new
                 {
                     AlbumName = a.Name,
                     ReleaseDate = $"{a.ReleaseDate:MM/dd/yyyy}",
                     ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = $"{s.Price:f2}",
                        SongWriterName = s.Writer.Name,
                    }).OrderByDescending(s => s.SongName).ThenBy(s => s.SongWriterName).ToList(),
                    AlbumPrice = a.Price,
                 }).ToList().OrderByDescending(a => a.AlbumPrice).ToList();
            var sb = new StringBuilder();
            int counter = 1;
            albums.ForEach(a =>
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");
                a.Songs.ForEach(s =>
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.SongWriterName}");
                    counter++;
                });
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:F2}");
                counter = 1;
            });

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new 
                {
                    SongName = s.Name,
                    Performers = s.SongPerformers.OrderBy(sp => sp.Performer.FirstName).ToList(),
                    WriterName = s.Writer.Name,
                    Duration = s.Duration.ToString("c"),
                    AlbumProducer = s.Album.Producer.Name,

                }).OrderBy(s => s.SongName).ThenBy(s => s.WriterName).ToList();

                
            var sb = new StringBuilder();
            var counter = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer.Performer.FirstName} {performer.Performer.LastName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
