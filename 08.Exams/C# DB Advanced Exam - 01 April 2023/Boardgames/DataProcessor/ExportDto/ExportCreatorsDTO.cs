using System.Xml.Serialization;
namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorsDTO
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [XmlElement("CreatorName")]
        public string CreatorName { get; set; } = null!;

        [XmlArray("Boardgames")]
        [XmlArrayItem("Boardgame")]
        public ExportBoardGameDTO[] Boardgames { get; set; } = null!;
    }
}
