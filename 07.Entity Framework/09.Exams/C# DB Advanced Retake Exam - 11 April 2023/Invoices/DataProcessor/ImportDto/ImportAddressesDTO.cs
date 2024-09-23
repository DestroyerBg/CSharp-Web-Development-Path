using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.DatabaseConstraints;
namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Address")]
    public class ImportAddressesDTO
    {
        [Required]
        [XmlElement("StreetName")]
        [MinLength(AddressStreetNameMinLength)]
        [MaxLength(AddressStreetNameMaxLength)]
        public string StreetName { get; set; } = null!;

        [Required]
        [XmlElement("StreetNumber")]
        public int StreetNumber { get; set; }

        [Required]
        [XmlElement("PostCode")]
        public string PostCode { get; set; } = null!;

        [Required]
        [XmlElement("City")]
        [MinLength(AddressCityMinLength)]
        [MaxLength(AddressCityMaxLength)]
        public string City { get; set; } = null!;

        [Required]
        [XmlElement("Country")]
        [MinLength(AddressCountryMinLength)]
        [MaxLength(AddressCountryMaxLength)]
        public string Country { get; set; } = null!;
    }
}