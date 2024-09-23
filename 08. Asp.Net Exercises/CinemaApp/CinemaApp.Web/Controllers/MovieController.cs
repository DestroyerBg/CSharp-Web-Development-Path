using CinemaApp.Data.Context;
using CinemaApp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private CinemaAppContext _context;
        public MovieController(CinemaAppContext context)
        {
            _context = context;
        }
        public IActionResult AllMovies()
        {
            List<Movie> movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie movieModel)
        {
            Movie movie = new Movie()
            {
                Description = movieModel.Description,
                Director = movieModel.Director,
                Duration = movieModel.Duration,
                Genre = movieModel.Genre,
                ReleaseDate = movieModel.ReleaseDate,
                Title = movieModel.Title,
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        public IActionResult Details(Guid movieId)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(Guid movieId)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movieModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == movieModel.Id);
            
            movie.Title = movieModel.Title;
            movie.Description = movieModel.Description;
            movie.Director = movieModel.Director;
            movie.Duration = movieModel.Duration;
            movie.Genre = movieModel.Genre;
            movie.ReleaseDate = movieModel.ReleaseDate;
            _context.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        public IActionResult Delete(Guid movieId)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("AllMovies");
        }
    }
}
