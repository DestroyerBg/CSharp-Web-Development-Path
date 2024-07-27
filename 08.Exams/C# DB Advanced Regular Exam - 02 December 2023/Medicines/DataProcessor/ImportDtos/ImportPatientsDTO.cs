using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicines.Data;
using Newtonsoft.Json;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientsDTO
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(DataConstraints.PatientFullNameMinLength)]
        [MaxLength(DataConstraints.PatientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [JsonProperty("AgeGroup")]
        [Range(DataConstraints.PatientAgeGroupMinValue,DataConstraints.PatientAgeGroupMaxValue)]
        [Required]
        public int AgeGroup { get; set; }

        [JsonProperty("Gender")]
        [Range(DataConstraints.PatientGenderGroupMinValue, DataConstraints.PatientGenderGroupMaxValue)]
        [Required]
        public int Gender { get; set; }

        [JsonProperty("Medicines")]
        [Required]
        public int[] Medicines { get; set; }
    }
}
