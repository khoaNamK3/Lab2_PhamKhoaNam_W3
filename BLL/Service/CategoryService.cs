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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GameCategory>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<GameCategory> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

    }
}
