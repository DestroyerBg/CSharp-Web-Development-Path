using GameZone.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Data.Configurations
{
    public class GamerGameConfiguration : IEntityTypeConfiguration<GamerGame>
    {
        public void Configure(EntityTypeBuilder<GamerGame> builder)
        {
            builder.HasKey(pk => new { pk.GameId, pk.GamerId });

            builder.HasOne(p => p.Game)
                .WithMany(g => g.GamersGames)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
