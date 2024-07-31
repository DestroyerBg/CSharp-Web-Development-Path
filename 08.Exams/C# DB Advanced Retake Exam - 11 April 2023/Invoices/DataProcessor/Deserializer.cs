using System.Globalization;
using System.Text;
using FlexiParser;
using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using Invoices.DataProcessor.ImportDto;

namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Invoices.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            ImportClientsDTO[] clientsDTos = XmlParser.DeserializeXML<ImportClientsDTO[]>(xmlString, "Clients");
            StringBuilder sb = new StringBuilder();

            foreach (ImportClientsDTO clientDto in clientsDTos)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                };

                foreach (ImportAddressesDTO addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        City = addressDto.City,
                        Country = addressDto.Country,
                        PostCode = addressDto.PostCode,
                        StreetNumber = addressDto.StreetNumber
                    };
                    client.Addresses.Add(address);
                }

                context.Clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            ImportInvoicesDTO[] invoicesDtos = JsonParser.ParseJson<ImportInvoicesDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            foreach (ImportInvoicesDTO invoiceDto in invoicesDtos)
            {
                bool isDueDateValid = DateTime.TryParse(invoiceDto.DueDate, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dueDate);
                bool isIssueDateValid = DateTime.TryParse(invoiceDto.IssueDate, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime issueDate);
                bool isDueDateBeforeIssueDate = dueDate < issueDate;
                Client searchClient = context.Clients.FirstOrDefault(c => c.Id == invoiceDto.ClientId);

                if (!IsValid(invoiceDto) || searchClient == null 
                                         || isDueDateBeforeIssueDate == true 
                                         || !isDueDateValid 
                                         || !isIssueDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice invoice = new Invoice()
                {
                    Amount = invoiceDto.Amount,
                    ClientId = invoiceDto.ClientId,
                    CurrencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), invoiceDto.CurrencyType.ToString()),
                    DueDate = dueDate,
                    IssueDate = issueDate,
                    Number = invoiceDto.Number,
                };

                context.Invoices.Add(invoice);
                sb.AppendLine(string.Format(SuccessfullyImportedInvoices, invoice.Number));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            ImportProductsDTO[] productsDtos = JsonParser.ParseJson<ImportProductsDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (ImportProductsDTO productDto in productsDtos)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new Product()
                {
                    CategoryType = (CategoryType)Enum.Parse(typeof(CategoryType), productDto.CategoryType.ToString()),
                    Name = productDto.Name,
                    Price = productDto.Price,
                };

                foreach (int clientId in productDto.Clients.Distinct())
                {
                    Client? searchClient = context.Clients.FirstOrDefault(c => c.Id == clientId);
                    if (searchClient == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProductClient productClient = new ProductClient()
                    {
                        Product = product,
                        ClientId = clientId,
                    };

                    product.ProductsClients.Add(productClient);
                }

                context.Products.Add(product);
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count));
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
