using System.Globalization;
using System.Linq;
using System.Net;
using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using FlexiParser;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.DateOfAcquisition >=
                            DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .ToArray()
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens.Select(c => new
                    {
                        LastName = c.Citizen.LastName,
                        MaritalStatus = c.Citizen.MaritalStatus.ToString(),
                    }).OrderBy(c => c.LastName)
                        .ToArray()
                }).ToArray();

            return JsonParser.GetJson(properties, false);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDTO()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                }).ToArray();

            return XmlParser.SerializeToXml(properties, "Properties");

        }
    }
}
