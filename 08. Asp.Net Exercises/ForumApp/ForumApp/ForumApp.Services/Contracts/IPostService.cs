using ForumApp.Data.Models;
using ForumApp.ViewModels;
using ForumApp.ViewModels.CommentModels;
using ForumApp.ViewModels.PostModels;

namespace ForumApp.Services.Contracts
{
    public interface IPostService
    {
        Task AddPost(ImportPostViewModel postModel);

        Task<bool> DeletePost(string guid);

        Task<bool> UpdatePost(ImportPostUpdateViewModel postModel);

        Task<IEnumerable<ExportPostViewModel>> GetPosts();

        Task<Post> GetPostById(string guid, bool isIncludeComments = false);

        ImportPostUpdateViewModel CreateModelFromPost(Post post);
        Task<bool> AddCommentToPost(CommentViewModel commentModel, string postId);

        Task<PostWithCommentsViewModel> CreatePostWithCommentViewModel(string postId);

        Task<bool> PostComment(CommentViewModel commentModel);
        Task<bool> DeleteAllComments(string postId);
    }
}
