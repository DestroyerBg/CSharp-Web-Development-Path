using CinemaApp.Data.Context;
using CinemaApp.Data.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaAppContext context;

        public CinemaController(CinemaAppContext _context)
        {
            context = _context;
        }
        public IActionResult AllCinemas()
        {
            IList<Cinema> cinemas = context.Cinemas
                .OrderByDescending(c => c.Location)
                .ToList();

            IList<CinemaIndexViewModel> cinemasModels = cinemas
                .Select(c => new CinemaIndexViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Location,
                }).ToList();

            return View(cinemasModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CinemaCreateViewModel cinemaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaModel);
            }

            Cinema cinema = new Cinema()
            {
                Name = cinemaModel.Name,
                Location = cinemaModel.Location,
            };

            context.Cinemas.Add(cinema);
            context.SaveChanges();
            return RedirectToAction("AllCinemas");
        }

        public IActionResult Details(string cinemaId)
        {
            bool isGuidValid = Guid.TryParse(cinemaId, out Guid id);
            if (!isGuidValid)
            {
                return RedirectToAction("AllCinemas");
            }

            Cinema cinema = context
                .Cinemas
                .Include(c => c.CinemaMovies)
                .ThenInclude(c => c.Movie)
                .FirstOrDefault(c => c.Id == id);

            if (cinema == null)
            {
                return RedirectToAction("AllCinemas");
            }


            CinemaDetailsViewModel cinemaDetails = new CinemaDetailsViewModel()
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Movies = cinema.CinemaMovies.Select(cm => new MovieProgramViewModel()
                    {
                        Title = cm.Movie.Title,
                        Duration = cm.Movie.Duration,
                    }).OrderByDescending(m => m.Title)
                    .ToHashSet()
            };

            return View(cinemaDetails);
        }

    }
}
