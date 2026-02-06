using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;

namespace AuthService.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users =
        [
            new User(
                Guid.NewGuid(),
                "admin",
                BCrypt.Net.BCrypt.HashPassword("password"))
        ];

        public Task<User?> GetByUsernameAsync(string username)
        {
            return Task.FromResult(
                Users.SingleOrDefault(u => u.Username == username));
        }
    }
}