using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static TravelAgency.Data.Common.DatabaseConstraints;
namespace TravelAgency.DataProcessor.ImportDtos
{
    public class ImportBookingsDTO
    {
        [Required]
        [JsonProperty("BookingDate")]
        public string BookingDate { get; set; } = null!;

        [Required]
        [JsonProperty("CustomerName")]
        public string CustomerName { get; set; } = null!;

        [Required]
        [JsonProperty("TourPackageName")]
        public string TourPackageName { get; set; } = null!;
    }
}
