using AutoMapper;
using Horizons.Data.Models;
using Horizons.Models.ViewModels;

namespace Horizons.Automapper
{
    public class TerrainProfiles : Profile
    {
        public TerrainProfiles()
        {
            CreateMap<Terrain, TerrainViewModel>();
        }
    }
}
