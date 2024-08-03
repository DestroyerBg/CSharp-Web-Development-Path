using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using FlexiParser;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            ImportCustomersDTO[] customersDtos = XmlParser.DeserializeXML<ImportCustomersDTO[]>(xmlString, "Customers");

            StringBuilder sb = new StringBuilder();

            foreach (ImportCustomersDTO customersDto in customersDtos)
            {
                if (!IsValid(customersDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Customers.Any(c => c.FullName == customersDto.FullName) ||
                    context.Customers.Any(c => c.Email == customersDto.Email) ||
                    context.Customers.Any(c => c.PhoneNumber == customersDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    Email = customersDto.Email,
                    FullName = customersDto.FullName,
                    PhoneNumber = customersDto.PhoneNumber,
                };

                context.Customers.Add(customer);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            ImportBookingsDTO[] bookingsDtos = JsonParser.ParseJson<ImportBookingsDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (ImportBookingsDTO bookingDto in bookingsDtos)
            {
                bool isDateValid = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                if (!IsValid(bookingDto) || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Customer customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                TourPackage tourPackage = context.TourPackages.FirstOrDefault(t => t.PackageName == bookingDto.TourPackageName);
                Booking booking = new Booking()
                {
                    BookingDate = date,
                    Customer = customer,
                    TourPackage = tourPackage,
                };

                context.Bookings.Add(booking);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName,
                    booking.BookingDate.ToString("yyyy-MM-dd")));
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
