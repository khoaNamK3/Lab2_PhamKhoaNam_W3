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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> Authenticate(string email, string password)
        {
            return await _userRepository.Authenticate(email, password);
        }
    }
}
