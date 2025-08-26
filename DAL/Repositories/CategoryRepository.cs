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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GameHubContext _gameHubContext;

        public CategoryRepository(GameHubContext gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task<List<GameCategory>> GetAll()
        {
            return await _gameHubContext.GameCategories.ToListAsync();
        }

        public async Task<GameCategory> GetCategoryById(int id)
        {
            return await _gameHubContext.GameCategories.FirstOrDefaultAsync(g => g.CategoryId == id);
        }
    }
}
