using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Data.Common.DatabaseConstraints;
namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardGameDTO
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(BoardGameNameMinLength)]
        [MaxLength(BoardGameNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Rating")]
        [Range(BoardGameMinRangeValue, BoardGameMaxRangeValue)]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        [Range(BoardGameMinYearPublishedValue, BoardGameMaxYearPublishedValue)]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(BoardGameCategoryTypeMinValue, BoardGameCategoryTypeMaxValue)]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
    }
}