using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictsDTO
    {
        public ImportDistrictsDTO()
        {
            Properties = new List<ImportPropertyDTO>();
        }

        [XmlAttribute("Region")]
        [Required]
        public string Region { get; set; }

        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }

        [XmlElement("PostalCode")]
        [MaxLength(8)]
        [MinLength(8)]
        [RegularExpression(@"[A-Z]{2}-[0-9]{5}")]
        [Required]
        public string PostalCode { get; set; }

        [XmlArray("Properties")]
        [XmlArrayItem("Property")]
        public List<ImportPropertyDTO> Properties { get; set; }
    }
    [XmlType("Property")]
    public class ImportPropertyDTO
    {
        [XmlElement("PropertyIdentifier")]
        [MinLength(16)]
        [MaxLength(20)]
        [Required] 
        public string PropertyIdentifier { get; set; }

        [XmlElement("Area")]
        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [XmlElement("Details")]
        [MinLength(5)]
        [MaxLength(500)]
        public string? Details { get; set; }

        [XmlElement("Address")]
        [MinLength(5)]
        [MaxLength(200)]
        [Required]
        public string Address { get; set; } = null!;

        [XmlElement("DateOfAcquisition")]
        [Required]
        public string DateOfAcquisition { get; set; } = null!;
    }
}
