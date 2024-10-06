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
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            IEnumerable<Post> posts = await context
                .Posts
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostById(Guid id, bool isIncludeComments = false)
        {
            Post post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);

            if (isIncludeComments == true)
            {
                await context.Entry(post).Collection(c => c.Comments).LoadAsync();
            }
            return post;
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        private async Task<IEnumerable<Comment>> GetCommentsOnPost(Guid postId)
        {
            IEnumerable<Comment> comments = await context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();

            return comments;
        }

        public async Task DeleteAllCommentsOnPost(Post post)
        {
            IEnumerable<Comment> comments = await GetCommentsOnPost(post.Id);

            context.Comments.RemoveRange(comments);

            await SaveChanges();

        }
    }
}
