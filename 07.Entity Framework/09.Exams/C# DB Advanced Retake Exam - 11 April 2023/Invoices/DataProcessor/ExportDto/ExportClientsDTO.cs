using System.Text;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsDTO
    {
        [XmlAttribute("InvoicesCount")]
        public string InvoicesCount { get; set; } = null!;

        [XmlElement("ClientName")]
        public string ClientName { get; set; } = null!;

        [XmlElement("VatNumber")]
        public string VatNumber { get; set; } = null!;

        [XmlArray("Invoices")]
        [XmlArrayItem("Invoice")]
        public ExportInvoicesDTO[] Invoices { get; set; } = null!;
    }
}
