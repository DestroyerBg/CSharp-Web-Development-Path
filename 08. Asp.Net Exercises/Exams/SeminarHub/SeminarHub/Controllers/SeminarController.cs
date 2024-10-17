using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeminarHub.Extensions;
using SeminarHub.Models.ViewModels;
using SeminarHub.Services;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarService seminarService;
        private readonly CategoryService categoryService;
        private readonly UserManager<IdentityUser> userManager;
        public SeminarController(
            SeminarService _seminarService,
            CategoryService _categoryService,
            UserManager<IdentityUser> _userManager)
        {
            seminarService = _seminarService;
            categoryService = _categoryService;
            userManager = _userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            AddSeminarViewModel model = await seminarService.CreateBlackSeminarModel(user);
            await model.LoadCategories(categoryService);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSeminarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await model.LoadCategories(categoryService);
                return View(model);
            }

            await seminarService.AddSeminar(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await seminarService.LoadSeminarsFromDatabaseAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction("All");
            }

            int seminarId = int.Parse(id);

            SeminarDetailsViewModel model = await seminarService.LoadDetailsForSeminar(seminarId);

            if (model == null)
            {
                return RedirectToAction("All");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction("All");
            }

            EditSeminarViewModel model = await seminarService.CreateSeminarEditModel(int.Parse(id));

            if (model == null)
            {
                return RedirectToAction("All");
            }

            if (model.OrganizerId != user.Id)
            {
                return RedirectToAction("All");
            }

            await model.LoadCategories(categoryService);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditSeminarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await model.LoadCategories(categoryService);
                return View(model);
            }

            bool isUpdatedCompletely = await seminarService.EditSeminar(model);

            if (!isUpdatedCompletely)
            {
                return View(model);
            }

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction("All");
            }

            DeleteSeminarViewModel model = await seminarService.CreateDeleteSeminarViewModel(int.Parse(id));

            if (model == null)
            {
                return RedirectToAction("Details", new {id = id});
            }

            if (user.Id != model.Organizer)
            {
                return RedirectToAction("Details", new { id = id });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(DeleteSeminarViewModel model)
        {
            await seminarService.DeleteSeminar(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            IdentityUser user = await userManager.GetUserAsync(User);

            ICollection<AllSeminarsViewModel> seminars = await seminarService.GetJoinedSeminars(user);

            return View(seminars);

        }

        [HttpPost]
        public async Task<IActionResult> Join(string id)
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction("Joined");
            }

            bool isAlreadyJoined = await seminarService.JoinToSeminar(int.Parse(id), user);

            if (!isAlreadyJoined)
            {
                return RedirectToAction("All");
            }
            return RedirectToAction("Joined");
        }

        [HttpPost]
        public async Task<IActionResult> Leave(string id)
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction("Joined");
            }

            await seminarService.LeaveSeminar(int.Parse(id), user);

            return RedirectToAction("Joined");
        }
    }
}
