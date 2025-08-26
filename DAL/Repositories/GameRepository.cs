using DAL.Models;
using DAL.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameHubContext _context;

        public GameRepository(GameHubContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAll()
        {
            return await _context.Games.Include(g => g.Category).Include(d => d.Developer).ToListAsync();
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games.Include(g => g.Category).Include(d => d.Developer).FirstOrDefaultAsync(g => g.GameId == id);
        }

        public async Task DeleteGame(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameById(int id, Game newGame)
        {
            var exitGame = await GetGameById(id);

            if (exitGame != null && newGame != null)
            {
               exitGame.Price = newGame.Price;
                exitGame.Title = newGame.Title;
                exitGame.ReleaseDate = newGame.ReleaseDate;
                exitGame.CategoryId = newGame.CategoryId;
                exitGame.DeveloperId = newGame.DeveloperId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task AddNewGameProfile(Game newGame)
        {
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
        }
    }
}
