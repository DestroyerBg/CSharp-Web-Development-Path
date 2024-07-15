using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.DTOs.Export
{
    public class CategoriesDTO
    {
        [JsonProperty("category")]
        public string CategoryName { get; set; }
        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }
        [JsonProperty("averagePrice")]
        public string AveragePrice { get; set; }
        [JsonProperty("totalRevenue")]
        public string TotalRevenue { get; set; }
    }
}
