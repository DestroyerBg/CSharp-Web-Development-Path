namespace Horizons.Models.ViewModels
{
    public class AllDestinationsViewModel
    {
        public int Id { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = null!;

        public string Terrain { get; set; } = null!;

        public int FavoritesCount { get; set; }

    }
}
