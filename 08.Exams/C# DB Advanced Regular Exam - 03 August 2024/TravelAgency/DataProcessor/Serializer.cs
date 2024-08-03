using System.ComponentModel.DataAnnotations;
using System.Globalization;
using FlexiParser;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            ExportGuidelinesDTO[] guidelines = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuidelinesDTO()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tp => new ExportTourPackageDTO()
                        {
                            Description = tp.TourPackage.Description,
                            Name = tp.TourPackage.PackageName,
                            Price = tp.TourPackage.Price
                        }).OrderByDescending(p => p.Price)
                        .ThenBy(a => a.Name)
                        .ToArray()
                }).OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            return XmlParser.SerializeToXml(guidelines, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .ToArray()
                .Select(c => new
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings.Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                    {
                        TourPackageName = b.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                    }).ToArray(),
                }).OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName);

            return JsonParser.GetJson(customers, false);
        }
    }
}
