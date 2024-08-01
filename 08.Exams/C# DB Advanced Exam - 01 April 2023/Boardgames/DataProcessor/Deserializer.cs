using System.Text;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using FlexiParser;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            ImportCreatorDTO[] creatorDtos = XmlParser.DeserializeXML<ImportCreatorDTO[]>(xmlString, "Creators");
            StringBuilder sb = new StringBuilder();

            foreach (ImportCreatorDTO creatorDto in creatorDtos)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                };

                foreach (ImportBoardGameDTO boardGameDto in creatorDto.BoardGames)
                {
                    if (!IsValid(boardGameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardGameDto.Name,
                        CategoryType = Enum.Parse<CategoryType>(boardGameDto.CategoryType.ToString()),
                        Creator = creator,
                        Mechanics = boardGameDto.Mechanics,
                        Rating = boardGameDto.Rating,
                        YearPublished = boardGameDto.YearPublished,
                    };

                    creator.Boardgames.Add(boardgame);
                }

                context.Creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));

            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportSellerDTO[] sellerDtos = JsonParser.ParseJson<ImportSellerDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            foreach (ImportSellerDTO sellerDto in sellerDtos)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Name = sellerDto.Name,
                    Website = sellerDto.Website,
                };

                foreach (int boardgameId in sellerDto.Boardgames.Distinct())
                {
                    if (!context.Boardgames.Any(b => b.Id == boardgameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boardgameId,
                        Seller = seller,
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                context.Sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
