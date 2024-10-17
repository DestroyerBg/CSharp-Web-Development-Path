using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.DatabaseModels;

namespace SeminarHub.Services
{
    public class CategoryService
    {
        private readonly SeminarHubDbContext context;

        public CategoryService(SeminarHubDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
             return await context.Categories.ToListAsync();
        }
    }
}
