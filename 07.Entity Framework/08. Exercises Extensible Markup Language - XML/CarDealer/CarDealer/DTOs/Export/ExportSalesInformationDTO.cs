using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Models;

namespace CarDealer.DTOs.Export
{
    public class ExportSalesInformationDTO
    {
        public Car Car { get; set; }

        public decimal Discount { get; set; }
    }
}
