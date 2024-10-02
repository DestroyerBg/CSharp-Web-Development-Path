using ForumApp.Data.Core;
using ForumApp.Data.Models;
using ForumApp.Repos.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Repos
{
    public class PostRepo : IRepo
    {
        private ForumAppContext context;

        public PostRepo(ForumAppContext _context)
        {   
            context = _context;
        }
        public async Task AddPost(Post post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task DeletePost(Guid postId)
        {
            Post post = await context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            post.IsDeleted = true;
            context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            IEnumerable<Post> posts = await context
                .Posts
                .ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostById(Guid id)
        {
            Post post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
