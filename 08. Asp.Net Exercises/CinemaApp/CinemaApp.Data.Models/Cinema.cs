using System.ComponentModel.DataAnnotations;
using static CinemaApp.Data.Constraints.CinemaConstraints;
namespace CinemaApp.Data.Models
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(LocationMaxLength)]
        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new HashSet<CinemaMovie>();
    }
}
