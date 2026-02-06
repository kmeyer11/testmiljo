using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Application.UseCases.Login
{
    public record LoginCommand(string Username, string Password);
}