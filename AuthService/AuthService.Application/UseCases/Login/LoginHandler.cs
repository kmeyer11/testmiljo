using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application.Interfaces;

namespace AuthService.Application.UseCases.Login
{
    public class LoginHandler
    {
        private readonly IUserRepository _users;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtTokenGenerator _jwt;

        public LoginHandler(
            IUserRepository users,
            IPasswordHasher hasher,
            IJwtTokenGenerator jwt)
        {
            _users = users;
            _hasher = hasher;
            _jwt = jwt;
        }

        public async Task<string?> Handle(LoginCommand command)
        {
            var user = await _users.GetByUsernameAsync(command.Username);
            if (user == null)
                return null;

            if (!_hasher.Verify(command.Password, user.PasswordHash))
                return null;

            return _jwt.Generate(user);
        }
    }
}