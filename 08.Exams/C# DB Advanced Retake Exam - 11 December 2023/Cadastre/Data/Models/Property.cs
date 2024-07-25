using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class Property
    {
        public Property()
        {
            PropertiesCitizens = new HashSet<PropertyCitizen>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(16)]
        [MaxLength(20)]
        public string PropertyIdentifier  { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Area { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        public string? Details { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfAcquisition { get; set; }
        [Required]
        [ForeignKey(nameof(District))]
        public int DistrictId { get; set; }

        public District District { get; set; }

        public ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }
}
