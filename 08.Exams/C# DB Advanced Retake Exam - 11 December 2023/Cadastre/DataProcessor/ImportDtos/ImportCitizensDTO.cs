using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastre.Data.Enumerations;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizensDTO
    {
        [JsonProperty("FirstName")]
        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        [JsonProperty("BirthDate")]
        [Required]
        public string BirthDate { get; set; }

        [JsonProperty("MaritalStatus")]
        [Required]
        public string MaritalStatus { get; set; }
        [JsonProperty]
        public int[] Properties { get; set; }
    }
}
