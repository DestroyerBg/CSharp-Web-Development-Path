using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services;

namespace DeskMarket.Extensions
{
    public static class ApplicationExtensions
    {
        public static async Task LoadCategories(this AddProductViewModel model, CategoryService service)
        {
            ICollection<Category> categories = await service.GetCategories();

            model.Categories = categories;
        }

        public static bool CheckIsValidDigit(this string value)
        {
            bool isValid = int.TryParse(value, out int result);

            return isValid;
        }

        public static async Task LoadCategories(this EditProductViewModel model, CategoryService service)
        {
            ICollection<Category> categories = await service.GetCategories();

            model.Categories = categories;
        }
    }
}
