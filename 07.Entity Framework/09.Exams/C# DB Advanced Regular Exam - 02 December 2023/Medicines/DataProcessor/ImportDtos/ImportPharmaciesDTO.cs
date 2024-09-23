
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Medicines.Data;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmaciesDTO
    {
        [XmlAttribute("non-stop")] 
        [Required] 
        public string NonStop { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MinLength(DataConstraints.PharmacyNameMinLength)]
        [MaxLength(DataConstraints.PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("PhoneNumber")]
        [Required]
        [MinLength(DataConstraints.PhoneNumberMaxLength)]
        [MaxLength(DataConstraints.PhoneNumberMaxLength)]
        [RegularExpression(DataConstraints.PhoneNumberRegexPattern)]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public ImportMedicinesDTO[] Medicines { get; set; } = null!;

    }
}
