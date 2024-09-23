using System.Globalization;
using System.Text;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using FlexiParser;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var distritctsDTos = XmlParser.DeserializeXML<ImportDistrictsDTO[]>(xmlDocument, "Districts");
            var sb = new StringBuilder();

            foreach (var districtDto in distritctsDTos)
            {
                if (!IsValid(districtDto) || !Enum.TryParse(districtDto.Region, out Region region))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), districtDto.Region),
                };

                foreach (var propertyDTO in districtDto.Properties)
                {
                    if (!IsValid(propertyDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(d => d.PropertyIdentifier == propertyDTO.PropertyIdentifier)
                        || district.Properties.Any(d => d.PropertyIdentifier == propertyDTO.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(d => d.Address == propertyDTO.Address)
                        || district.Properties.Any(d => d.Address == propertyDTO.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var property = new Property()
                    {
                        Area = propertyDTO.Area,
                        Address = propertyDTO.Address,
                        DateOfAcquisition =
                            DateTime.ParseExact(propertyDTO.DateOfAcquisition, "dd/MM/yyyy",
                                CultureInfo.InvariantCulture, DateTimeStyles.None),
                        Details = propertyDTO.Details,
                        District = district,
                        PropertyIdentifier = propertyDTO.PropertyIdentifier,
                    };

                    dbContext.Properties.Add(property);
                }

                dbContext.Districts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var sb = new StringBuilder();
            var citizensDTOs = JsonParser.ParseJson<ImportCitizensDTO[]>(jsonDocument);

            foreach (var citizenDTO in citizensDTOs)
            {
                if (!IsValid(citizenDTO) || !Enum.TryParse(citizenDTO.MaritalStatus, out MaritalStatus maritalStatus))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var citizen = new Citizen()
                {
                    FirstName = citizenDTO.FirstName,
                    LastName = citizenDTO.LastName,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), citizenDTO.MaritalStatus),
                    BirthDate = DateTime.ParseExact(citizenDTO.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None),
                };

                foreach (var propertyDTO in citizenDTO.Properties)
                {
                    var propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = propertyDTO
                    };
                    dbContext.PropertiesCitizens.Add(propertyCitizen);
                }

                dbContext.Citizens.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName,
                    citizen.PropertiesCitizens.Count));
            }

            dbContext.SaveChanges();

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
