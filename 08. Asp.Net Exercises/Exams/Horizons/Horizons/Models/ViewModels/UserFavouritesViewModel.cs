namespace Horizons.Models.ViewModels
{
    public class UserFavouritesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string Terrain { get; set; } = null!;

    }
}
