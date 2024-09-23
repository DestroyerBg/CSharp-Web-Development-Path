using System.ComponentModel.DataAnnotations;
namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstraints.PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DataConstraints.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsNonStop { get; set; }

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    }
}
