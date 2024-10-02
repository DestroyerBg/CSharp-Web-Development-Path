using ForumApp.Data.Models;
using ForumApp.ViewModels;

namespace ForumApp.Services.Contracts
{
    public interface IPostService
    {
        Task AddPost(ImportPostViewModel postModel);

        Task<bool> DeletePost(string guid);

        Task<bool> UpdatePost(ImportPostUpdateViewModel postModel);

        Task<IEnumerable<ExportPostViewModel>> GetPosts();

        bool ValidateGuid(string guid);


    }
}
