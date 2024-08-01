using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Boardgames.Data.Common.DatabaseConstraints;
namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDTO
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(SellerNameMinLength)]
        [MaxLength(SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("Address")]
        [MinLength(SellerAddressMinLength)]
        [MaxLength(SellerAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [JsonProperty("Website")]
        [RegularExpression(WebsiteRegexPattern)]
        public string Website { get; set; } = null!;

        [Required]
        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; } = null!;
    }
}
