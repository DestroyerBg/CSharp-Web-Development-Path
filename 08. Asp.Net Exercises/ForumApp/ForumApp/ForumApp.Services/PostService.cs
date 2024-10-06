using System.Collections;
using ForumApp.Data.Models;
using ForumApp.Repos;
using ForumApp.Repos.Contracts;
using ForumApp.Services.Contracts;
using ForumApp.ViewModels;
using ForumApp.ViewModels.CommentModels;
using ForumApp.ViewModels.PostModels;

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

            await postRepo.DeletePost(postId);
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

        public async Task<Post> GetPostById(string guid, bool isIncludeComments = false)
        {
            if (!ValidateGuid(guid))
            { 
                return null;
            }

            Guid id = Guid.Parse(guid);

            Post post = await postRepo.GetPostById(id, isIncludeComments);

            return post;

        }

        public ImportPostUpdateViewModel CreateModelFromPost(Post post)
        {
            ImportPostUpdateViewModel model = new ImportPostUpdateViewModel()
            {
                Content = post.Content,
                PostId = post.Id.ToString(),
                Title = post.Title,
            };

            return model;
        }

        public async Task<bool> AddCommentToPost(CommentViewModel commentModel, string postId)
        {
            if (!ValidateGuid(postId))
            {
                return false ;
            }

            Guid id = Guid.Parse(postId);

            Post? post = await postRepo.GetPostById(id, true);

            if (post == null)
            {
                return false;
            }

            Comment comment = CreateCommentFromViewModel(commentModel);

            post.Comments.Add(comment);

            await postRepo.SaveChanges();

            return true;
        }

        private Comment CreateCommentFromViewModel(CommentViewModel commentModel)
        {
            Comment comment = new Comment()
            {
                Content = commentModel.Content,
                Id = new Guid(),
                PublishedDate = commentModel.PublishedDate,
                Username = commentModel.Username
            };

            return comment;
        }

        public async Task<PostWithCommentsViewModel> CreatePostWithCommentViewModel(string postId)
        {
            Post? post = await GetPostById(postId, true);

            if (post == null)
            {
                return null;
            }


            PostWithCommentsViewModel model = new PostWithCommentsViewModel()
            {
                PostId = post.Id,
                PostTitle = post.Title,
                PostContent = post.Content,
                Comments = post.Comments.Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    Content = c.Content,
                    Username = c.Username,
                    PublishedDate = c.PublishedDate,
                    PostId = post.Id,
                }).OrderByDescending(c => c.PublishedDate).ToHashSet()
            };

            return model;
        }

        public async Task<bool> PostComment(CommentViewModel commentModel)
        {
            Post? post = await GetPostById(commentModel.PostId.ToString(), true);

            if (post == null)
            {
                return false;
            }

            Comment comment = CreateCommentFromViewModel(commentModel);

            post.Comments.Add(comment);

            await postRepo.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAllComments(string postId)
        {
            Post? post = await GetPostById(postId, true);

            if (post == null)
            {
                return false;
            }
            await postRepo.DeleteAllCommentsOnPost(post);

            return true;
        }

        private bool ValidateGuid(string guid)
        {
            bool isGuid = Guid.TryParse(guid, out Guid result);

            return isGuid;
        }
    }
}
