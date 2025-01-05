using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static DeskMarket.Constraints.ProductConstraints;
namespace DeskMarket.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxlength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = ProductPricePrecision)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public string SellerId { get; set; } = null!;

        public IdentityUser Seller { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
