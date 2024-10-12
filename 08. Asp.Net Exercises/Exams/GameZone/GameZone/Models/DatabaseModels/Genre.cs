using System.ComponentModel.DataAnnotations;
using static GameZone.Common.GenreConstraints;
namespace GameZone.Models.DatabaseModels
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}