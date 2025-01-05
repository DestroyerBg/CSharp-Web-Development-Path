using System.Security.Claims;
using Horizons.Models.ViewModels;

namespace Horizons.Services.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<AllDestinationsViewModel>> GetAllDestinations(ClaimsPrincipal claim);

        Task<AddDestinationViewModel> CreateDestinationViewModel();

        Task<bool> AddDestination(AddDestinationViewModel model, ClaimsPrincipal claim);

        Task<IEnumerable<UserFavouritesViewModel>> GetUserFavourites(ClaimsPrincipal claim);

        Task<bool> AddDestinationToUserFavourites(string id, ClaimsPrincipal claim);

        Task<bool> RemoveDestinationFromUserFavourites(string id, ClaimsPrincipal claim);

        Task<EditDestinationViewModel> CreateEditDestinationViewModel(string id, ClaimsPrincipal claim);

        Task<bool> EditDestination(EditDestinationViewModel model);

        Task<DestinationDetailsViewModel> GetDetailsForDestination(string id, ClaimsPrincipal claim);

        Task<DeleteDestinationViewModel> CreateDeleteDestinationModel(string id, ClaimsPrincipal claim);

        Task<bool> RemoveDestination(DeleteDestinationViewModel model, ClaimsPrincipal claim);

    }
}
