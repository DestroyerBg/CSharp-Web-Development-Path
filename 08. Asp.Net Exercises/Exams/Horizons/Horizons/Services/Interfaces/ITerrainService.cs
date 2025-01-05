using Horizons.Models.ViewModels;

namespace Horizons.Services.Interfaces
{
    public interface ITerrainService
    {
        Task<ICollection<TerrainViewModel>> GetTerrainsAsync();
    }
}
