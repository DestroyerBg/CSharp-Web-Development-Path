using System.Collections;
using ForumApp.Data.Models;
using ForumApp.Repos;
using ForumApp.Repos.Contracts;
using ForumApp.Services.Contracts;
using ForumApp.ViewModels;

namespace ForumApp.Services
{
    public class PostService : IPostService
    {
        private IRepo postRepo;

        public PostService(PostRepo _postRepo)
        {
            postRepo = _postRepo;
        }
        public async Task AddPost(ImportPostViewModel postModel)
        {
            Post post = new Post()
            {
                Content = postModel.Content,
                Id = new Guid(),
                Title = postModel.Title
            };

            await postRepo.AddPost(post);
        }

        public async Task<bool> DeletePost(string guid)
        {
            if (!ValidateGuid(guid))
            {
                return false;
            }

            Guid postId = Guid.Parse(guid);

            Post post = await postRepo.GetPostById(postId);

            if (post == null)
            {
                return false;
            }

            postRepo.DeletePost(postId);
            return true;
        }

        public async Task<bool> UpdatePost(ImportPostUpdateViewModel postModel)
        {
            if (!ValidateGuid(postModel.PostId))
            {
                return false;
            }

            Guid postId = Guid.Parse(postModel.PostId);

            Post post = await postRepo.GetPostById(postId);

            post.Content = postModel.Content;
            post.Title = postModel.Title;
            postRepo.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<ExportPostViewModel>> GetPosts()
        {
            IEnumerable<Post> postsModels = await 
                postRepo
                    .GetPosts();

            IEnumerable<ExportPostViewModel> posts = postsModels
                .Select(p => new ExportPostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Title = p.Title,
                }).ToList();

            return posts;
        }

        public bool ValidateGuid(string guid)
        {
            bool isGuid = Guid.TryParse(guid, out Guid result);

            return isGuid;
        }
    }
}
