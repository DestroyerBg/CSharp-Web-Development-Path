using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Trucks.Data.Common.DatabaseConstraints;
namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTrucksDTO
    {
        [Required]
        [XmlElement("RegistrationNumber")]
        [MinLength(TruckRegistrationNumberExactlyLength)]
        [MaxLength(TruckRegistrationNumberExactlyLength)]
        [RegularExpression(TruckRegistrationNumberRegexPattern)]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [XmlElement("VinNumber")]
        [MinLength(TruckVinNumberExactlyLength)]
        [MaxLength(TruckVinNumberExactlyLength)]
        public string VinNumber { get; set; } = null!;

        [Required]
        [XmlElement("TankCapacity")]
        [Range(TruckTankCapacityMinRange,TruckTankCapacityMaxRange)]
        public int TankCapacity { get; set; }

        [Required]
        [XmlElement("CargoCapacity")]
        [Range(TruckCargoCapacityMinRange,TruckCargoCapacityMaxRange)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(TruckCategoryTypeMinValue, TruckCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [Range(TruckMakeTypeMinValue,TruckMakeTypeMaxValue)]
        public int MakeType { get; set; }
    }
}