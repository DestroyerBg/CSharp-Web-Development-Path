using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using SeminarHub.Models.ViewModels;

namespace SeminarHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> signInManager;
        public HomeController(
            ILogger<HomeController> logger,
            SignInManager<IdentityUser> _signInManager)
        {
            _logger = logger;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("All", "Seminar");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}