using Horizons.Models.ViewModels;
using Horizons.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Horizons.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly ITerrainService terrainService;
        public DestinationController(IDestinationService _destinationService,
            ITerrainService _terrainService,
            UserManager<IdentityUser> _userManager)
        {
            destinationService = _destinationService;
            terrainService = _terrainService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllDestinationsViewModel> models = await destinationService.GetAllDestinations(User);
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            AddDestinationViewModel model = await destinationService.CreateDestinationViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddDestinationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Terrains = await terrainService.GetTerrainsAsync();
                return View(model);
            }

            bool isAddedSuccessfully = await destinationService.AddDestination(model, User);

            if (isAddedSuccessfully)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            EditDestinationViewModel model = await destinationService.CreateEditDestinationViewModel(id, User);

            if (model == null)
            {
                return RedirectToAction("Details");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditDestinationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Terrains = await terrainService.GetTerrainsAsync();
                return View(model);
            }

            bool isEditedSuccessfully = await destinationService.EditDestination(model);

            if (isEditedSuccessfully)
            {
                return RedirectToAction("Details", new{id = model.Id});
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteDestinationViewModel model = await destinationService.CreateDeleteDestinationModel(id, User);

            if (model == null)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteDestinationViewModel model)
        {
            await destinationService.RemoveDestination(model, User);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            DestinationDetailsViewModel model = await destinationService.GetDetailsForDestination(id, User);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Favorites()
        {
            IEnumerable<UserFavouritesViewModel> models = await destinationService.GetUserFavourites(User);

            return View(models);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorites(string id, string? returnUrl)
        {
            await destinationService.AddDestinationToUserFavourites(id, User);
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromFavorites(string id)
        {
            await destinationService.RemoveDestinationFromUserFavourites(id, User);

            return RedirectToAction("Favorites");
        }

    }
}
