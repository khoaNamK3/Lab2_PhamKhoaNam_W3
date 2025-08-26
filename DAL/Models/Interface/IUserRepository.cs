using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Interface
{
    public interface IUserRepository
    {
        public Task<User?> Authenticate(string email, string password);
    }
}
