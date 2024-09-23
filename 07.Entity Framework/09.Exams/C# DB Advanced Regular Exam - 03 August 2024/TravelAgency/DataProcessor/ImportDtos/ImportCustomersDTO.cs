using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Xml.Serialization;
using static TravelAgency.Data.Common.DatabaseConstraints;
namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomersDTO
    {
        [Required]
        [XmlAttribute("phoneNumber")]
        [MinLength(CustomerPhoneNumberExactlyLength)]
        [MaxLength(CustomerPhoneNumberExactlyLength)]
        [RegularExpression(CustomerPhoneNumberRegexPattern)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlElement("FullName")]
        [MinLength(CustomerFullNameMinlength)]
        [MaxLength(CustomerFullNameMaxlength)]
        public string FullName { get; set; } = null!;

        [Required]
        [XmlElement("Email")]
        [MinLength(CustomerEmailMinlength)]
        [MaxLength(CustomerEmailMaxlength)]
        public string Email { get; set; } = null!;
    }
}
