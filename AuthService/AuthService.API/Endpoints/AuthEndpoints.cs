using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Application.UseCases.Login;

namespace AuthService.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            app.MapPost("/login", async (
                HttpRequest request,
                LoginHandler handler) =>
            {
                var form = await request.ReadFormAsync();

                var command = new LoginCommand(
                    form["username"],
                    form["password"]);

                var token = await handler.Handle(command);

                if (token == null)
                    return Results.Unauthorized();

                return Results.Ok(new { token });
            });
        }
    }
}