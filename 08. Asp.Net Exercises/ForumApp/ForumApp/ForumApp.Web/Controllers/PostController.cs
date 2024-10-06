using ForumApp.Data.Models;
using ForumApp.Services;
using ForumApp.Services.Contracts;
using ForumApp.ViewModels;
using ForumApp.ViewModels.CommentModels;
using ForumApp.ViewModels.PostModels;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(PostService _postService)
        {
            postService = _postService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<ExportPostViewModel> posts = await postService.GetPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ImportPostViewModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postModel);
            }

            await postService.AddPost(postModel);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Delete(string postId)
        {
            await postService.DeleteAllComments(postId);
            await postService.DeletePost(postId);
            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string postId)
        {
            Post? post = await postService.GetPostById(postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            ImportPostUpdateViewModel model = postService.CreateModelFromPost(post);

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(ImportPostUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.UpdatePost(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> LoadComments(string postId)
        {
            PostWithCommentsViewModel model = await postService.CreatePostWithCommentViewModel(postId);

            if (model == null)
            {
                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("LoadComments", new { postId = model.PostId });
            }

            await postService.PostComment(model);

            return RedirectToAction("LoadComments", new { postId = model.PostId });
        }



    }
}
