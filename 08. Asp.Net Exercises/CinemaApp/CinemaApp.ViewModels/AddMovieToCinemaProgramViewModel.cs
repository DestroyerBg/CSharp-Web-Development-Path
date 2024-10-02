namespace CinemaApp.ViewModels
{
    public class AddMovieToCinemaProgramViewModel
    {
        public Guid MovieId { get; set; }

        public string MovieTitle { get; set; } = null!;

        public List<CinemaCheckBoxItem> Cinemas { get; set; } = new List<CinemaCheckBoxItem>();
    }
}
