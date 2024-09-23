using System.Net.Http.Headers;
using Boardgames.DataProcessor.ExportDto;
using FlexiParser;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            List<ExportCreatorsDTO> creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToList()
                .Select(c => new ExportCreatorsDTO()
                {
                    BoardgamesCount = c.Boardgames.Count(),
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    Boardgames = c.Boardgames.Select(b => new ExportBoardGameDTO()
                    {
                        BoardgameName = b.Name,
                        YearPublished = b.YearPublished,
                    }).OrderBy(b => b.BoardgameName)
                        .ToArray()
                }).OrderByDescending(b => b.BoardgamesCount)
                .ThenBy(b => b.CreatorName)
                .ToList();

            return XmlParser.SerializeToXml(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers.Any(b => b.Boardgame.YearPublished >= year
                && b.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                        .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                        .Select(b => new
                        {
                            Name = b.Boardgame.Name,
                            Rating = b.Boardgame.Rating,
                            Mechanics = b.Boardgame.Mechanics,
                            Category = b.Boardgame.CategoryType.ToString(),
                        }).OrderByDescending(b => b.Rating)
                        .ThenBy(b => b.Name)
                        .ToArray()
                }).OrderByDescending(b => b.Boardgames.Count())
                .ThenBy(b => b.Name)
                .Take(5)
                .ToArray();

            return JsonParser.GetJson(sellers, false);
        }
    }
}