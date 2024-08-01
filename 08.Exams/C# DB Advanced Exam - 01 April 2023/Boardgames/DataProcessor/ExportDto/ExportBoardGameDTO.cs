using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class ExportBoardGameDTO
    {
        [XmlElement("BoardgameName")]
        public string BoardgameName { get; set; } = null!;

        [XmlElement("BoardgameYearPublished")]
        public int YearPublished { get; set; }
    }
}