using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Domain.Entities;

namespace AuthService.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string Generate(User user);
    }
}