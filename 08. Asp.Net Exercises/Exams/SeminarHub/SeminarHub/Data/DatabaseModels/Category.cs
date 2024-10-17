using System.ComponentModel.DataAnnotations;
using static SeminarHub.Constraints.CategoryConstraints;
namespace SeminarHub.Data.DatabaseModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxlength)]
        public string Name { get; set; } = null!;

        public ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
    }
}