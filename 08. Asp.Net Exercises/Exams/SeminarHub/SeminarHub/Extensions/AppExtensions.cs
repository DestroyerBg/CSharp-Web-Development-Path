using SeminarHub.Data.DatabaseModels;
using SeminarHub.Models.ViewModels;
using SeminarHub.Services;

namespace SeminarHub.Extensions
{
    public static class AppExtensions
    {
        public static async Task LoadCategories(this AddSeminarViewModel model, CategoryService service)
        {
            ICollection<Category> categories = await service.GetCategoriesAsync();

            model.Categories = categories;
        }

        public static bool CheckIsValidDigit(this string value)
        {
            bool isValid = int.TryParse(value, out int result);

            return isValid;
        }

        public static async Task LoadCategories(this EditSeminarViewModel model, CategoryService service)
        {
            ICollection<Category> categories = await service.GetCategoriesAsync();

            model.Categories = categories;
        }
    }
}
