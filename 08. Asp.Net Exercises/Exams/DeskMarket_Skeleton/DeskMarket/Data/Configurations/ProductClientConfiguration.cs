using DeskMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeskMarket.Data.Configurations
{
    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
        {
            builder.HasKey(pk => new { pk.ClientId, pk.ProductId });

            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductsClients)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
