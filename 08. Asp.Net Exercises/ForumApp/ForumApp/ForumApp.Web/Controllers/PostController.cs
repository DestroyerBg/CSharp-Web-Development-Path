using ForumApp.Services;
using ForumApp.Services.Contracts;
using ForumApp.ViewModels;
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
        public IActionResult Add(ImportPostViewModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postModel);
            }

            postService.AddPost(postModel);

            return RedirectToAction("All");
        }
    }
}
