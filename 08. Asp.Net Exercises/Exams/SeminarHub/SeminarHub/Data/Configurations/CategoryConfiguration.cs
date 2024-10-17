using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeminarHub.Data.DatabaseModels;

namespace SeminarHub.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Category> SeedData()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Technology & Innovation"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Business & Entrepreneurship"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Science & Research"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Arts & Culture"
                },
            };

            return categories;

        }
    }
}