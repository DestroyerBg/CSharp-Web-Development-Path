using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ExportUsersProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("users")]
        [XmlArrayItem("User")]
        public ExportUsersInformationDTO[] Users { get; set; }
    }
}
