
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Newtonsoft.Json;
using static Invoices.Data.Common.DatabaseConstraints;
namespace Invoices.DataProcessor.ImportDto
{
    public class ImportInvoicesDTO
    {
        [Required]
        [JsonProperty("Number")]
        [Range(InvoiceNumberMinRange,InvoiceNumberMaxRange)]
        public int Number { get; set; }

        [Required]
        [JsonProperty("IssueDate")]
        public string IssueDate { get; set; } = null!;

        [Required]
        [JsonProperty("DueDate")]
        public string DueDate { get; set; } = null!;

        [Required]
        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [JsonProperty("CurrencyType")]
        [Range(InvoiceCurrencyTypeMinRange,InvoiceCurrencyTypeMaxRange)]
        public int CurrencyType { get; set; }

        [Required]
        [JsonProperty("ClientId")]
        public int ClientId { get; set; }
    }
}
