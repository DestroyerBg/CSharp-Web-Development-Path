using System.Globalization;
using AutoMapper;
using Horizons.Data.Models;
using Horizons.Models.ViewModels;
using static Horizons.Common.DatabaseModelsConstants.Destination;
namespace Horizons.Automapper
{
    public class DestinationProfiles : Profile
    {
        public DestinationProfiles()
        {
            CreateMap<AddDestinationViewModel, Destination>()
                .ForMember(dest => dest.PublishedOn, src =>
                    src.MapFrom(s => DateTime.ParseExact(s.PublishedOn, DateFormat, CultureInfo.InvariantCulture,
                        DateTimeStyles.None)))
                .ForMember(dest => dest.TerrainId, src => 
                    src.MapFrom(s => int.Parse(s.TerrainId)));

            CreateMap<Destination, UserFavouritesViewModel>()
                .ForMember(dest => dest.Terrain, src =>
                    src.MapFrom(s => s.Terrain.Name));

            CreateMap<Destination, EditDestinationViewModel>()
                .ForMember(dest => dest.Terrains, src => src.Ignore())
                .ForMember(dest => dest.PublishedOn, src => 
                    src.MapFrom(s => s.PublishedOn.ToString(DateFormat, CultureInfo.InvariantCulture)));

            CreateMap<EditDestinationViewModel, Destination>()
                .ForMember(dest => dest.PublishedOn, src =>
                    src.MapFrom(s => DateTime.ParseExact(s.PublishedOn, DateFormat, CultureInfo.InvariantCulture,
                        DateTimeStyles.None)));

            CreateMap<Destination, DeleteDestinationViewModel>()
                .ForMember(dest => dest.Publisher, src => src.MapFrom(s => s.Publisher.UserName));

        }
    }
}
