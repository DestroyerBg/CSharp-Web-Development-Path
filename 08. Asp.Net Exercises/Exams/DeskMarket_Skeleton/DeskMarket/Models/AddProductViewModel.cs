using DeskMarket.Data.Models;
using System.ComponentModel.DataAnnotations;
using DeskMarket.Attributes;
using static DeskMarket.Constraints.ProductConstraints;
namespace DeskMarket.Models
{
    public class AddProductViewModel
    {
        
        [Required]
        [WordLength(ProductNameMinLength, ProductNameMaxLength, ProductNameErrorMessage)]
        public string ProductName { get; set; } = null!;

        [Required]
        [WordLength(DescriptionMinlength, DescriptionMaxlength, DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), PriceMinRange, PriceMaxRange,
            ErrorMessage = $"Price should be between {PriceMinRange} and {PriceMaxRange}$.")]
        public decimal Price { get; set; } = 0;

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;


        [Required]
        [Date(DateFormat, DateFormatError)]
        public string AddedOn { get; set; } = DateTime.Now.ToString(DateFormat);

        [Required]
        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
