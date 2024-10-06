using System.Runtime.CompilerServices;
using ForumApp.Data.Models;

namespace ForumApp.Repos.Contracts
{
    public interface IRepo
    {
        Task AddPost(Post post);

        Task DeletePost(Guid postId);

        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPostById(Guid id, bool isIncludeComments = false);

        Task SaveChanges();

        Task DeleteAllCommentsOnPost(Post post);

    }
}
