using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models
{
    public class District
    {
        public District()
        {
            Properties = new HashSet<Property>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [RegularExpression(@"[A-Z]{2}-[0-9]{5}")]
        public string PostalCode { get; set; }
        [Required]
        public Region Region { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
