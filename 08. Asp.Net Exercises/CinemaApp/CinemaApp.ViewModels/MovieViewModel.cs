using System.ComponentModel.DataAnnotations;
using static CinemaApp.Data.Constraints.MovieConstraints;
namespace CinemaApp.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            ReleaseDate = DateTime.Today;
        }
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MinLength(GenreMinLength)]
        [MaxLength(GenreMaxLength)]
        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        [MinLength(DirectorNameMinLength)]
        [MaxLength(DirectorNameMaxLength)]
        public string Director { get; set; } = null!;

        [Range(DurationMinValue,DurationMaxValue)]
        public int Duration { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

    }
}
