using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Core.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(SeedData());
        }

        private List<Post> SeedData()
        {
            List<Post> posts = new List<Post>
            {
                new Post { Id = Guid.NewGuid(), Title = "Post 1", Content = "Content for post 1." },
                new Post { Id = Guid.NewGuid(), Title = "Post 2", Content = "Content for post 2." },
                new Post { Id = Guid.NewGuid(), Title = "Post 3", Content = "Content for post 3." },
                new Post { Id = Guid.NewGuid(), Title = "Post 4", Content = "Content for post 4." },
                new Post { Id = Guid.NewGuid(), Title = "Post 5", Content = "Content for post 5." }
            };

            return posts;
        }
    }
}
