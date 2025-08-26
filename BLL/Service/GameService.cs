using BLL.Interface;
using DAL.Models;
using DAL.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task AddNewGameProfile(Game newGame)
        {
           await _gameRepository.AddNewGameProfile(newGame);
        }

        public async Task DeleteGame(Game game)
        {
            await  _gameRepository.DeleteGame(game);
        }

        public async Task<List<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _gameRepository.GetGameById(id);
        }

        public async Task UpdateGameById(int id, Game newGame)
        {
             await _gameRepository.UpdateGameById(id, newGame);
        }
    }
}
