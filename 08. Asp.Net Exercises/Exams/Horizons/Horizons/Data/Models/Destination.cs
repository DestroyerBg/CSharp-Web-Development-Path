using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static Horizons.Common.DatabaseModelsConstants.Destination;
namespace Horizons.Data.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxlength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public string PublisherId { get; set; } = null!;

        [Required]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Terrain))]
        public int TerrainId { get; set; }

        [Required]
        public Terrain Terrain { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<UserDestination> UsersDestinations { get; set; } = new HashSet<UserDestination>();
    }

}
