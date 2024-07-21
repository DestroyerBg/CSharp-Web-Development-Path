using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportSoldProductsArrayDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        [XmlArrayItem("Product")]
        public ExportSoldProducts[] Products { get; set; }

    }
}