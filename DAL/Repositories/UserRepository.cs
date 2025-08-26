using DAL.Models;
using DAL.Models.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameHubContext _gameHubContext;
        private readonly PasswordHasher<string> _passwordHasher;
        public UserRepository(GameHubContext gameHubContext)
        {
            _gameHubContext = gameHubContext;
            _passwordHasher = new PasswordHasher<string>();
        }

        public async Task<User?> Authenticate(string email, string password)
        {
            var userAccount = await _gameHubContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (userAccount == null)
            {
                return null;
            }

            string dbhasherPassword = userAccount.PasswordHash;

            return VerifyPassword(dbhasherPassword, password) ? userAccount : null;
        }


        public string CreateHashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string dbHashPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, dbHashPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
