using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeminarHub.Data.DatabaseModels;

namespace SeminarHub.Data.Configurations
{
    public class SeminarParticipantConfiguration : IEntityTypeConfiguration<SeminarParticipant>
    {
        public void Configure(EntityTypeBuilder<SeminarParticipant> builder)
        {
            builder.HasKey(pk => new { pk.ParticipantId, pk.SeminarId });

            builder.HasOne(p => p.Seminar)
                .WithMany(s => s.SeminarsParticipants)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
