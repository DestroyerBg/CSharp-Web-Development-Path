using GameZone.Models.DatabaseModels;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GenreService genreService;
        private readonly GameService gameService;
        private readonly UserManager<IdentityUser> userManager;

        public GameController(
            GenreService _genreService,
            GameService _gameService,
            UserManager<IdentityUser> _userManager)
        {
            genreService = _genreService;
            gameService = _gameService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ICollection<Genre> genres = await genreService.LoadAllGenres();
            IdentityUser user = await userManager.GetUserAsync(User);
            GameAddViewModel model = gameService.CreateBlankGameAddViewModel(genres, user);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(GameAddViewModel model)
        {
            model.Genres = new SelectList(await genreService.LoadAllGenres(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await gameService.AddGame(model);

            return RedirectToAction("All");
        }

        [HttpGet]

        public async Task<IActionResult> All()
        {
            IEnumerable<AllGamesViewModel> gameModels = await gameService.GetAllGames();

            return View(gameModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidId = int.TryParse(id, out int gameId);
            if (!isValidId)
            {
                return RedirectToAction("All");
            }

            Game game = await gameService.FindGameByIdAsync(gameId);
            GameDetailsViewModel model = await gameService.CreateGameModel(game);
            if (game == null)
            {
                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isValidId = int.TryParse(id, out int gameId);
            if (!isValidId)
            {
                return RedirectToAction("All");
            }

            Game game = await gameService.FindGameByIdAsync(gameId);
            if (game == null)
            {
                return RedirectToAction("All");
            }
            IdentityUser user = await userManager.GetUserAsync(User);
            if (user.Id != game.PublisherId)
            {
                return RedirectToAction("All");
            }
            ICollection<Genre> genres = await genreService.LoadAllGenres();
            EditGameViewModel model = gameService.CreateEditGameViewModel(genres, user, game);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGameViewModel model)
        {
            model.Genres = new SelectList(await genreService.LoadAllGenres(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isCompleted = await gameService.EditGame(model);
            if (!isCompleted)
            {
                return View(model);
            }

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isValid = int.TryParse(id, out int gameId);

            if (!isValid)
            {
                return RedirectToAction("All");
            }

            DeleteGameViewModel model = await gameService.CreateDeleteGameViewModel(gameId);

            if (model == null)
            {
                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await gameService.DeleteGame(id);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            IdentityUser user = await userManager.GetUserAsync(User);

            IEnumerable<AllGamesViewModel> games = await gameService.GetAllGames(user);

            return View(games);

        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(string id)
        {
            bool isValid = int.TryParse(id, out int gameId);

            if (!isValid)
            {
                return RedirectToAction("All");
            }

            IdentityUser user = await userManager.GetUserAsync(User);
            bool isAddedSuccessfully = await gameService.AddGameToUserZone(gameId, user);

            if (!isAddedSuccessfully)
            {
                return RedirectToAction("All");
            }

            return RedirectToAction("MyZone");
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(string id)
        {
            bool isValid = int.TryParse(id, out int gameId);

            if (!isValid)
            {
                return RedirectToAction("MyZone");
            }

            IdentityUser user = await userManager.GetUserAsync(User);

            await gameService.DeleteGameFromUserZone(gameId, user);

            return RedirectToAction("MyZone");
        }
    }
}
