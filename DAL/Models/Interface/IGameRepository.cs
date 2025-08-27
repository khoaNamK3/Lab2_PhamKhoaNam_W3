using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Interface
{
    public interface IGameRepository
    {
        public  Task<List<Game>> GetAll();
        public  Task<Game> GetGameById(int id);
        public  Task DeleteGame(Game game);
        public  Task UpdateGameById(int id, Game newGame);
        public  Task AddNewGameProfile(Game newGame);
        public  Task<List<Game>> SearchGameByPrice(decimal price);
    }
}
