using System.Globalization;
using GameZone.Common;
using GameZone.Data;
using GameZone.Models.DatabaseModels;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class GenreService
    {
        private readonly GameZoneDbContext context;

        public GenreService(GameZoneDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<Genre>> LoadAllGenres()
        {
            return await context.Genres.ToListAsync();
        }
    }
}
