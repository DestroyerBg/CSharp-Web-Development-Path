using CinemaApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CinemaApp.Data.Context;

namespace CinemaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Welcome to the Cinema Web App!";
            return View();
        }

    }
}
