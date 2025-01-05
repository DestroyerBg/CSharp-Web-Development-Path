using AutoMapper;
using Horizons.Data;
using Horizons.Models.ViewModels;
using Horizons.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services
{
    public class TerrainService : ITerrainService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public TerrainService(ApplicationDbContext _context,
            IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        public async Task<ICollection<TerrainViewModel>> GetTerrainsAsync()
        {
            ICollection<TerrainViewModel> models = await context.Terrains
                .Select(t => mapper.Map<TerrainViewModel>(t))
                .ToListAsync();

            return models;
        }
    }
}
