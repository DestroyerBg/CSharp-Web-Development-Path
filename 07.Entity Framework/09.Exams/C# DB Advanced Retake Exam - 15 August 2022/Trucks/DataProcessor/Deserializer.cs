using System.Text;
using FlexiParser;
using Microsoft.Data.SqlClient;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            ImportDespatchersDTO[] despatchersDtos =
                XmlParser.DeserializeXML<ImportDespatchersDTO[]>(xmlString, "Despatchers");

            StringBuilder sb = new StringBuilder();

            foreach (ImportDespatchersDTO despatcherDto in despatchersDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                foreach (ImportTrucksDTO truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)Enum.Parse(typeof(CategoryType), truckDto.CategoryType.ToString()),
                        Despatcher = despatcher,
                        MakeType = (MakeType)Enum.Parse(typeof(MakeType), truckDto.MakeType.ToString()),
                        RegistrationNumber = truckDto.RegistrationNumber,
                        TankCapacity = truckDto.TankCapacity,
                        VinNumber = truckDto.VinNumber,
                    };

                    despatcher.Trucks.Add(truck);
                }

                context.Despatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));

            }

            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientDTO[] clientDtos = JsonParser.ParseJson<ImportClientDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            foreach (ImportClientDTO clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type.ToLower() == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (int id in clientDto.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(t => t.Id == id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = id,
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }

                context.Clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));

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