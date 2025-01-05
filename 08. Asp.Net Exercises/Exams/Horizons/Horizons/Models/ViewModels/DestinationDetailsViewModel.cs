namespace Horizons.Models.ViewModels
{
    public class DestinationDetailsViewModel
    {
        public int Id { get; set; }

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = null!;

        public string Terrain { get; set; } = null!;

        public int FavoritesCount { get; set; }

        public string Description { get; set; } = null!;

        public DateTime PublishedOn { get; set; }

        public string Publisher { get; set; } = null!;
    }
}
