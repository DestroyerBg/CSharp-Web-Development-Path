using DeskMarket.Attributes;
using DeskMarket.Data.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace DeskMarket.Models
{
    public class AllProductsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public string UserId { get; set; } = null!;

        public bool HasBought { get; set; }

    }
}
