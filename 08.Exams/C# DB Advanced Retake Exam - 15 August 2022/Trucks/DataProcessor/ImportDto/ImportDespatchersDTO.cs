using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Trucks.Data.Common.DatabaseConstraints;
namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatchersDTO
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(DespatcherNameMinLength)]
        [MaxLength(DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; } = null!;

        [Required]
        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public ImportTrucksDTO[] Trucks { get; set; } = null!;
    }
}
