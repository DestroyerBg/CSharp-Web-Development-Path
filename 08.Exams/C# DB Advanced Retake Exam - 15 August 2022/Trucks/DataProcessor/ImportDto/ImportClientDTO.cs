using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Trucks.Data.Common.DatabaseConstraints;
namespace Trucks.DataProcessor.ImportDto
{
    public class ImportClientDTO
    {
        [Required]
        [JsonProperty("Name")]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [JsonProperty("Nationality")]
        [MinLength(ClientNationalityMinLength)]
        [MaxLength(ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; } = null!;

        [Required]
        [JsonProperty("Trucks")]
        public int[] Trucks { get; set; } = null!;
    }
}
