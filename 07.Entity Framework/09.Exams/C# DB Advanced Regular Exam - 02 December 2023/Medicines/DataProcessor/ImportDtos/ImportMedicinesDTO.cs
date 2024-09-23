using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;
using Medicines.Data;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicinesDTO
    {
        [XmlAttribute("category")]
        [Required]
        [Range(DataConstraints.CategoryMinValue, DataConstraints.CategoryMaxValue)]
        public int Category { get; set; }

        [XmlElement("Name")]
        [Required]
        [MinLength(DataConstraints.MedicineNameMinLength)]
        [MaxLength(DataConstraints.MedicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        [Required]
        [Range(typeof(decimal), DataConstraints.PriceMinRange, DataConstraints.PriceMaxRange)]
        public decimal Price { get; set; }

        [XmlElement("ProductionDate")]
        [Required]
        public string ProductionDate { get; set; } = null!;

        [XmlElement("ExpiryDate")] 
        [Required] 
        public string ExpiryDate { get; set; } = null!;

        [XmlElement("Producer")]
        [Required]
        [MinLength(DataConstraints.ProducerMinLength)]
        [MaxLength(DataConstraints.ProducerMaxLength)]
        public string Producer { get; set; } = null!;

        [XmlIgnore]
        public DateTime ProductionDateDate
        {
            get => DateTime.ParseExact(ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        [XmlIgnore]
        public DateTime ExpiryDateDate
        {
            get => DateTime.ParseExact(ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}