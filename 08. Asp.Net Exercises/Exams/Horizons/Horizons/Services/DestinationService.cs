using System.Security.Claims;
using AutoMapper;
using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Models.ViewModels;
using Horizons.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        private IMapper mapper;
        private ITerrainService terrainService;
        public DestinationService(UserManager<IdentityUser> _userManager,
            ApplicationDbContext _context,
            IMapper _mapper,
            ITerrainService _terrainService)
        {
            userManager = _userManager;
            context = _context;
            mapper = _mapper;
            terrainService = _terrainService;
        }
        public async Task<IEnumerable<AllDestinationsViewModel>> GetAllDestinations(ClaimsPrincipal claim)
        {
            IdentityUser? user = await GetUserAsync(claim);

            IEnumerable<AllDestinationsViewModel> models = await context.Destinations
                .Include(d => d.Terrain)
                .Select(d => new AllDestinationsViewModel()
                {
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = user!= null && d.PublisherId == user.Id,
                    IsFavorite = user != null && d.UsersDestinations.Any(u => u.UserId == user.Id),
                    Id = d.Id,
                    ImageUrl = d.ImageUrl,
                    Name = d.Name,
                    Terrain = d.Terrain.Name
                }).ToListAsync();

            return models;
        }

        public async Task<AddDestinationViewModel> CreateDestinationViewModel()
        {
            AddDestinationViewModel destinationModel = new AddDestinationViewModel();

            destinationModel.Terrains = await LoadTerrains();

            return destinationModel;
        }

        public async Task<bool> AddDestination(AddDestinationViewModel model, ClaimsPrincipal claim)
        {
            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return false;
            }

            Destination destination = mapper.Map<Destination>(model);

            destination.PublisherId = user.Id;

            try
            {
                await context.Destinations.AddAsync(destination);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<EditDestinationViewModel> CreateEditDestinationViewModel(string id, ClaimsPrincipal claim)
        {
            bool isValid = int.TryParse(id, out int result);

            if (!isValid)
            {
                return null;
            }

            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == result);

            if (!isDestAvailable)
            {
                return null;
            }

            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return null;
            }

            Destination? destination = await context.Destinations
                .FindAsync(result);

            if (destination.PublisherId != user.Id)
            {
                return null;
            }

            EditDestinationViewModel model = mapper.Map<EditDestinationViewModel>(destination);

            model.Terrains = await LoadTerrains();

            return model;
        }

        public async Task<bool> EditDestination(EditDestinationViewModel model)
        {
            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == model.Id);

            if (!isDestAvailable)
            {
                return false;
            }

            Destination? destination = await context.Destinations
                .FindAsync(model.Id);

            mapper.Map<EditDestinationViewModel, Destination>(model, destination);

            try
            {
                context.Entry(destination).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<DeleteDestinationViewModel> CreateDeleteDestinationModel(string id, ClaimsPrincipal claim)
        {
            bool isValid = int.TryParse(id, out int result);

            if (!isValid)
            {
                return null;
            }

            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == result);

            if (!isDestAvailable)
            {
                return null;
            }

            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return null;
            }

            Destination? destination = await context.Destinations
                .FindAsync(result);

            if (destination.PublisherId != user.Id)
            {
                return null;
            }

            DeleteDestinationViewModel? model = await context.Destinations
                .Where(d => d.Id == result)
                .Include(d => d.Publisher)
                .Select(d => mapper.Map<DeleteDestinationViewModel>(d))
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return null;
            }

            return model;
        }

        public async Task<bool> RemoveDestination(DeleteDestinationViewModel model, ClaimsPrincipal claim)
        {
            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == model.Id);

            if (!isDestAvailable)
            {
                return false;
            }

            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return false;
            }


            Destination? destination = await context.Destinations
                .FindAsync(model.Id);

            if (destination.PublisherId != user.Id)
            {
                return false;
            }

            destination.IsDeleted = true;

            IList<UserDestination> userDestinations = await context.UsersDestinations
                .Where(d => d.DestinationId == destination.Id)
                .ToListAsync();

            if (!userDestinations.Any())
            {
                context.UsersDestinations.RemoveRange(userDestinations);
            }

            try
            {
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserFavouritesViewModel>> GetUserFavourites(ClaimsPrincipal claim)
        {
            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return null;
            }

            IEnumerable<UserFavouritesViewModel> models = await context.Destinations
                .Include(d => d.Terrain)
                .Include(d => d.UsersDestinations)
                .Where(d => d.UsersDestinations.Any(ud => ud.UserId == user.Id))
                .Select(d => mapper.Map<UserFavouritesViewModel>(d))
                .ToListAsync();

            return models;
        }

        public async Task<bool> AddDestinationToUserFavourites(string id, ClaimsPrincipal claim)
        {
            bool isValid = int.TryParse(id, out int result);

            if (!isValid)
            {
                return false;
            }

            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == result);

            if (!isDestAvailable)
            {
                return false;
            }

            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return false;
            }

            if (context.UsersDestinations.Any(ud => ud.DestinationId == result && ud.UserId == user.Id))
            {
                return false;
            }
            UserDestination ud = new UserDestination()
            {
                DestinationId = result,
                UserId = user.Id,
            };

            try
            {
                await context.UsersDestinations.AddAsync(ud);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public async Task<bool> RemoveDestinationFromUserFavourites(string id, ClaimsPrincipal claim)
        {
            bool isValid = int.TryParse(id, out int result);

            if (!isValid)
            {
                return false;
            }

            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == result);

            if (!isDestAvailable)
            {
                return false;
            }

            IdentityUser? user = await GetUserAsync(claim);

            if (user == null)
            {
                return false;
            }

            UserDestination? userDestination = await context.UsersDestinations
                .FirstOrDefaultAsync(ud => ud.DestinationId == result && ud.UserId == user.Id);

            if (userDestination == null)
            {
                return false;
            }

            try
            {
                context.UsersDestinations.Remove(userDestination);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public async Task<DestinationDetailsViewModel> GetDetailsForDestination(string id, ClaimsPrincipal claim)
        {
            bool isValid = int.TryParse(id, out int result);

            if (!isValid)
            {
                return null;
            }

            bool isDestAvailable = await context.Destinations.AnyAsync(d => d.Id == result);

            if (!isDestAvailable)
            {
                return null;
            }

            IdentityUser? user = await GetUserAsync(claim);

            DestinationDetailsViewModel? model = await context.Destinations
                .Where(d => d.Id == result)
                .Include(d => d.Terrain)
                .Include(d => d.Publisher)
                .Select(d => new DestinationDetailsViewModel()
                {
                    FavoritesCount = d.UsersDestinations.Count,
                    IsPublisher = user != null && d.PublisherId == user.Id,
                    IsFavorite = user != null && d.UsersDestinations.Any(u => u.UserId == user.Id),
                    Id = d.Id,
                    ImageUrl = d.ImageUrl,
                    Name = d.Name,
                    Terrain = d.Terrain.Name,
                    PublishedOn = d.PublishedOn,
                    Publisher = d.Publisher.UserName,
                    Description = d.Description
                })
                .FirstOrDefaultAsync(d => d.Id == result);

            return model;
        }

        private async Task<ICollection<TerrainViewModel>> LoadTerrains()
        {
            ICollection<TerrainViewModel> terrainModels = await terrainService.GetTerrainsAsync();

            return terrainModels;
        }
        private async Task<IdentityUser> GetUserAsync(ClaimsPrincipal claim)
        {
            IdentityUser? user = await userManager.GetUserAsync(claim);

            return user;
        }

    }
}
