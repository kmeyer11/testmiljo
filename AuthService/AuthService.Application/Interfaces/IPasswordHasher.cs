using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Application.Interfaces
{
    public interface IPasswordHasher
    {
        bool Verify(string password, string passwordHash);
    }
}