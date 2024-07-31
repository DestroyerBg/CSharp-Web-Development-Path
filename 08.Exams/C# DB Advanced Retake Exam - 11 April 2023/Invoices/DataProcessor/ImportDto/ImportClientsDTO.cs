using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Data.Common.DatabaseConstraints;
namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ImportClientsDTO
    {
        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        [XmlElement("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("NumberVat")]
        [MinLength(ClientNumberVatMinLength)]
        [MaxLength(ClientNumberVatMaxLength)]
        public string NumberVat { get; set; } = null!;


        [XmlArray("Addresses")]
        [XmlArrayItem("Address")]
        public ImportAddressesDTO[] Addresses { get; set; } = null!;


    }
}
