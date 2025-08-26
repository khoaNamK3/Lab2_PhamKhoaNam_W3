using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Interface
{
    public interface ICategoryRepository
    {
        public  Task<List<GameCategory>> GetAll();
        public  Task<GameCategory> GetCategoryById(int id);

    }
}
