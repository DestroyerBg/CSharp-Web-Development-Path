using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations
{
    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> builder)
        {
            builder.HasKey(pk => new { pk.DestinationId, pk.UserId });

            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(d => d.DestinationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
