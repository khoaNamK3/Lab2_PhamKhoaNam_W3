using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICategoryService
    {
        public Task<List<GameCategory>> GetAll();
        public Task<GameCategory> GetCategoryById(int id);
    }
}
