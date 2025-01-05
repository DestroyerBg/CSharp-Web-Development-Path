using DeskMarket.Extensions;
using DeskMarket.Models;
using DeskMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace DeskMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;
        private readonly UserManager<IdentityUser> userManager;

        public ProductController(CategoryService _categoryService,
            ProductService _productService,
            UserManager<IdentityUser> _userManager)
        {
            categoryService = _categoryService;
            productService = _productService;
            userManager = _userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            IdentityUser user = await userManager.GetUserAsync(User);
            AddProductViewModel model = productService.CreateBlankAddProductViewModel(user);
            await model.LoadCategories(categoryService);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await model.LoadCategories(categoryService);
                return View(model);
            }

            await productService.AddProductToDatabase(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ICollection<AllProductsViewModel> productModels = await productService.LoadProductsAsync();

            return View(productModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction(nameof(Index));
            }

            ProductDetailsViewModel model = await productService.LoadDetailsForProductAsync(int.Parse(id));

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction(nameof(Index));
            }

            IdentityUser? user = await userManager.GetUserAsync(User);
            EditProductViewModel model = await productService.CreateEditModel(int.Parse(id), user);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            model.LoadCategories(categoryService);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isEditCompleted = await productService.EditProduct(model);

            if (!isEditCompleted)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Details), new{id = model.Id.ToString()});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction(nameof(Index));
            }

            IdentityUser? user = await userManager.GetUserAsync(User);

            DeleteProductViewModel? model = await productService.CreateDeleteProductModel(int.Parse(id), user);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isDeleted = await productService.DeleteProductFromDatabase(model);

            if (isDeleted == false)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Cart()
        {
            IdentityUser? user = await userManager.GetUserAsync(User);

            ICollection<ProductCartViewModel> models = await productService.GetUserCart(user);

            return View(models);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToCart(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction(nameof(Index));
            }

            IdentityUser? user = await userManager.GetUserAsync(User);

            await productService.AddProductToUserCart(user, int.Parse(id));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            if (!id.CheckIsValidDigit())
            {
                return RedirectToAction(nameof(Index));
            }

            IdentityUser? user = await userManager.GetUserAsync(User);

            await productService.RemoveFromCart(user, int.Parse(id));

            return RedirectToAction(nameof(Cart));
        }
    }
}
