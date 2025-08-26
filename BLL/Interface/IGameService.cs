using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IGameService
    {
        public Task<List<Game>> GetAll();
        public Task<Game> GetGameById(int id);
        public Task DeleteGame(Game game);
        public Task UpdateGameById(int id, Game newGame);
        public Task AddNewGameProfile(Game newGame);
    }
}
