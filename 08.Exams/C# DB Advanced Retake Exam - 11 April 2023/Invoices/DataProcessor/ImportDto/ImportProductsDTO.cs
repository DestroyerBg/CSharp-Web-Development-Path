using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Invoices.Data.Common.DatabaseConstraints;
namespace Invoices.DataProcessor.ImportDto
{
    public class ImportProductsDTO
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Price")]
        [Required]
        [Range(typeof(decimal), ProductPriceMinRange, ProductPriceMaxRange)]
        public decimal Price { get; set; }

        [JsonProperty("CategoryType")]
        [Required]
        [Range(ProductCategoryTypeMinValue,ProductCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [JsonProperty("Clients")]
        [Required]
        public int[] Clients { get; set; } = null!;
    }
}
