using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DeskMarket.Data.Models
{
    public class ProductClient
    {
        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = null!;
        public IdentityUser Client { get; set; } = null!;
    }
}