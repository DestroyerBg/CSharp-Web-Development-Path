using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static CinemaApp.Data.Constraints.MovieConstraints; 
namespace CinemaApp.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Director { get; set; } = null!;

        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<CinemaMovie> CinemaMovies { get; set; } = new HashSet<CinemaMovie>();
        public bool IsDeleted { get; set; } = false;
    }
}
