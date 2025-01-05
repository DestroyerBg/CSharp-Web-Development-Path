using Horizons.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using static Horizons.Common.DatabaseModelsConstants.Destination;
using static Horizons.Common.DababaseModelsMessages.Destination;
namespace Horizons.Models.ViewModels
{
    public class EditDestinationViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxlength, MinimumLength = NameMinlength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [DateValidation(DateFormat, ErrorWithParsingDate)]
        public string PublishedOn { get; set; }

        [Required]
        public string TerrainId { get; set; } = null!;

        [Required]
        public string PublisherId { get; set; } = null!;

        public ICollection<TerrainViewModel> Terrains { get; set; } = new HashSet<TerrainViewModel>();
    }
}
