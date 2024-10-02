using CinemaApp.Data.Context;
using CinemaApp.Data.Models;
using CinemaApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : Controller
    {
        private CinemaAppContext context;
        public MovieController(CinemaAppContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> AllMovies()
        {
            List<Movie> movies =  await context.Movies.ToListAsync();
            return View(movies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieViewModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }
            Movie movie = new Movie()
            {
                Description = movieModel.Description,
                Director = movieModel.Director,
                Duration = movieModel.Duration,
                Genre = movieModel.Genre,
                ReleaseDate = movieModel.ReleaseDate,
                Title = movieModel.Title,
            };
            context.Movies.AddAsync(movie);
            context.SaveChangesAsync();
            return RedirectToAction("AllMovies");
        }

        public async Task<IActionResult> Details(Guid movieId)
        {
            Movie movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid movieId)
        {
            Movie movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie movieModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            Movie movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieModel.Id);
            
            movie.Title = movieModel.Title;
            movie.Description = movieModel.Description;
            movie.Director = movieModel.Director;
            movie.Duration = movieModel.Duration;
            movie.Genre = movieModel.Genre;
            movie.ReleaseDate = movieModel.ReleaseDate;
            await context.SaveChangesAsync();
            return RedirectToAction("AllMovies");
        }

        public async Task<IActionResult> Delete(Guid movieId)
        {
            Movie movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction("AllMovies");
        }

        [HttpGet]
        public async Task<IActionResult> AddToProgram(string movieId)
        {
            bool isValidGuid = Guid.TryParse(movieId, out Guid id);

            if (!isValidGuid)
            {
                return RedirectToAction("AllMovies");
            }

            Movie movie = await context.Movies
                .Include(c => c.CinemaMovies)
                .ThenInclude(cm => cm.Cinema)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return RedirectToAction("AllMovies");
            }

            List<Cinema> cinemas = await context.Cinemas.ToListAsync();

            AddMovieToCinemaProgramViewModel viewModel = new AddMovieToCinemaProgramViewModel()
            {
                MovieId = id,
                MovieTitle = movie.Title,
                Cinemas = cinemas.Select(c => new CinemaCheckBoxItem()
                {
                    Id = c.Id,
                    IsSelected = movie.CinemaMovies.Any(cm => cm.Cinema.Id == c.Id),
                    Name = c.Name,
                }).ToList()


            };

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Movie movie = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == model.MovieId);

            if (movie == null)
            {
                return View(model);
            }

            IEnumerable<CinemaMovie> recordsToDelete = await context.CinemaMovies
                .Where(cm => cm.MovieId == movie.Id)
                .ToListAsync();

            context.CinemaMovies.RemoveRange(recordsToDelete);

            foreach (CinemaCheckBoxItem cinema in model.Cinemas)
            {
                if (cinema.IsSelected)
                {
                    CinemaMovie cinemaMovie = new CinemaMovie()
                    {
                        CinemaId = cinema.Id,
                        MovieId = model.MovieId,
                    };
                    movie.CinemaMovies.Add(cinemaMovie);
                }
            }

            context.SaveChangesAsync();

            return RedirectToAction("AllMovies");
        }
    }
}
