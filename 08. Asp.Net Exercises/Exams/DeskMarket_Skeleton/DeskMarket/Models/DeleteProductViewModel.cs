namespace DeskMarket.Models
{
    public class DeleteProductViewModel
    {
        public int Id { get; set; }

        public string Seller { get; set; } = null!;

        public string SellerId { get; set; } = null!;

        public string ProductName { get; set; } = null!;
    }
}
