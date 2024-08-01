using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Data.Common.DatabaseConstraints;
namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDTO
    {
        [Required]
        [XmlElement("FirstName")]
        [MinLength(CreatorFirstNameMinLength)]
        [MaxLength(CreatorFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [XmlElement("LastName")]
        [MinLength(CreatorLastNameMinLength)]
        [MaxLength(CreatorLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [XmlArray("Boardgames")]
        [XmlArrayItem("Boardgame")]
        public ImportBoardGameDTO[] BoardGames { get; set; } = null!;

    }
}
