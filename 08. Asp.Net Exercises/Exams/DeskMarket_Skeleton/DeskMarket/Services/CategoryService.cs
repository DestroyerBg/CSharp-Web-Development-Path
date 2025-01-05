using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            ICollection<Category> categories = await context.Categories.ToListAsync();

            return categories;
        }
    }
}
