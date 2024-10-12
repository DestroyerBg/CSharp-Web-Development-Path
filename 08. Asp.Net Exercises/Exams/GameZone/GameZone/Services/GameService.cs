using GameZone.Models.DatabaseModels;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using GameZone.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.GameConstraints;
using System;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Services
{
    public class GameService
    {
        private readonly GameZoneDbContext context;

        public GameService(GameZoneDbContext _context)
        {
            context = _context;
        }
        public GameAddViewModel CreateBlankGameAddViewModel(ICollection<Genre> genres, IdentityUser user)
        {
            SelectList genreList = new SelectList(genres, "Id", "Name");

            GameAddViewModel viewModel = new GameAddViewModel()
            {
                Genres = genreList,
                ReleasedOn = DateTime.UtcNow.ToString(PublishedDateFormat, CultureInfo.InvariantCulture),
                PublisherId = user.Id,
            };

            return viewModel;
        }

        public EditGameViewModel CreateEditGameViewModel(ICollection<Genre> genres,
            IdentityUser user,
            Game game)
        {
            SelectList genreList = new SelectList(genres, "Id", "Name");

            EditGameViewModel viewModel = new EditGameViewModel()
            {
                Genres = genreList,
                ReleasedOn = DateTime.UtcNow.ToString(PublishedDateFormat, CultureInfo.InvariantCulture),
                PublisherId = user.Id,
                Description = game.Description,
                GenreId = game.GenreId,
                ImageUrl = game.ImageUrl,
                Title = game.Title,
                Id = game.Id,
            };

            return viewModel;
        }

        public async Task AddGame(GameAddViewModel model)
        {
            Game game = new Game()
            {
                Description = model.Description,
                GenreId = model.GenreId,
                ImageUrl = model.ImageUrl,
                PublisherId = model.PublisherId,
                Title = model.Title,
                ReleasedOn = DateTime.ParseExact(model.ReleasedOn, PublishedDateFormat, null, DateTimeStyles.None),
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllGamesViewModel>> GetAllGames()
        {
            IEnumerable<AllGamesViewModel> games = await context.Games
                .Include(g => g.Publisher)
                .Include(g => g.Genre)
                .OrderByDescending(g => g.Title)
                .Select(g => new AllGamesViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(PublishedDateFormat),
                    Publisher = g.Publisher.UserName,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                })
                .ToListAsync();

            return games;

        }

        public async Task<IEnumerable<AllGamesViewModel>> GetAllGames(IdentityUser user)
        {
            IEnumerable<AllGamesViewModel> games = await context.Games
                .Include(g => g.Publisher)
                .Include(g => g.Genre)
                .Where(g => g.GamersGames.Any(g => g.GamerId == user.Id))
                .OrderByDescending(g => g.Title)
                .Select(g => new AllGamesViewModel()
                {
                    Id = g.Id,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(PublishedDateFormat),
                    Publisher = g.Publisher.UserName,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                })
                .ToListAsync();

            return games;

        }

        public async Task<Game> FindGameByIdAsync(int gameId)
        {
            Game game = await context.Games
                .Include(g => g.Genre)
                .Include(g => g.Publisher)
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return null;
            }

            return game;
        }

        public async Task<GameDetailsViewModel> CreateGameModel(Game game)
        {
            GameDetailsViewModel model = new GameDetailsViewModel()
            {
                Description = game.Description,
                Genre = game.Genre.Name,
                Id = game.Id,
                ImageUrl = game.ImageUrl,
                Publisher = game.Publisher.UserName,
                ReleasedOn = game.ReleasedOn.ToString(PublishedDateFormat),
                Title = game.Title,
            };

            return model;
        }

        public async Task<bool> EditGame(EditGameViewModel model)
        {
            Game game = await context.Games.FirstOrDefaultAsync(g => g.Id == model.Id);
            if (game == null)
            {
                return false;
            }

            game.ImageUrl = model.ImageUrl;
            game.Description = model.Description;
            game.Title = model.Title;
            game.GenreId = model.GenreId;
            game.PublisherId = model.PublisherId;
            game.ReleasedOn = DateTime.ParseExact(model.ReleasedOn, PublishedDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<DeleteGameViewModel> CreateDeleteGameViewModel(int gameId)
        {
            Game game = await context.Games
                .Include(g => g.Publisher)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return null;
            }

            DeleteGameViewModel model = new DeleteGameViewModel()
            {
                Id = game.Id,
                Publisher = game.Publisher.UserName,
                Title = game.Title
            };

            return model;
        }

        public async Task<bool> DeleteGame(int id)
        {
            Game game = await context.Games
                .Include(g => g.Publisher)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return false;
            }

            IList<GamerGame> gamerGames = await context.GamersGames
                .Where(g => g.GameId == game.Id)
                .ToListAsync();

            context.GamersGames.RemoveRange(gamerGames);

            context.Games.Remove(game);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddGameToUserZone(int gameId, IdentityUser user)
        {
            Game game = await context.Games
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return false;
            }

            if (game.GamersGames.Any(g => g.GamerId == user.Id))
            {
                return false;
            }

            GamerGame gamerGame = new GamerGame()
            {
                GameId = gameId,
                GamerId = user.Id,
            };

            game.GamersGames.Add(gamerGame);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGameFromUserZone(int gameId, IdentityUser user)
        {
            Game game = await context.Games
                .Include(g => g.GamersGames)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                return false;
            }

            GamerGame gamerGame = await context.GamersGames
                .FirstOrDefaultAsync(g => g.GameId == gameId && g.GamerId == user.Id);

            if (gamerGame == null)
            {
                return false;
            }

            context.GamersGames.Remove(gamerGame);

            await context.SaveChangesAsync();

            return true;
        }

    }
}
