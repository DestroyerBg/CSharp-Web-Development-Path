namespace CinemaApp.ViewModels
{
    public class CinemaDetailsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public HashSet<MovieProgramViewModel> Movies { get; set; } = new HashSet<MovieProgramViewModel>();
        
}
}
