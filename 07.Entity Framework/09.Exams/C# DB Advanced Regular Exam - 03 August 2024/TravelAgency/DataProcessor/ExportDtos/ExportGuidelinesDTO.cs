using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("Guide")]
    public class ExportGuidelinesDTO
    {
        [XmlElement("FullName")]
        public string FullName { get; set; } = null!;

        [XmlArray("TourPackages")]
        [XmlArrayItem("TourPackage")]
        public ExportTourPackageDTO[] TourPackages { get; set; } = null!;
    }
}
