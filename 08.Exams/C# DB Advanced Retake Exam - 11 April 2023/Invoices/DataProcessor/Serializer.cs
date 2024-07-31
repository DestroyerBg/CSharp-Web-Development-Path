using System.Globalization;
using FlexiParser;
using Invoices.Data.Models;
using Invoices.DataProcessor.ExportDto;

namespace Invoices.DataProcessor
{
    using Invoices.Data;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            ExportClientsDTO[] clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientsDTO()
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    InvoicesCount = c.Invoices.Count.ToString(),
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoicesDTO()
                        {
                            Currency = i.CurrencyType.ToString(),
                            DueDate = i.DueDate.ToString("d",CultureInfo.InvariantCulture),
                            InvoiceAmount = i.Amount,
                            InvoiceNumber = i.Number,
                        })
                        .ToArray()
                }).OrderByDescending(c => c.Invoices.Length)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return XmlParser.SerializeToXml(clients, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any(c => c.Client.Name.Length >= nameLength))
                .ToArray()
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients.Where(c => c.Client.Name.Length >= nameLength)
                        .Select(c => new
                        {
                            Name = c.Client.Name,
                            NumberVat = c.Client.NumberVat,
                        }).OrderBy(c => c.Name)
                }).OrderByDescending(c => c.Clients.Count())
                .ThenBy(c => c.Name)
                .Take(5);

            return JsonParser.GetJson(products, false);
        }
    }
}