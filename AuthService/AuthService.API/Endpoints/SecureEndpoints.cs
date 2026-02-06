using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace AuthService.API.Endpoints
{
    public static class SecureEndpoints
{
    public static void MapSecureEndpoints(this WebApplication app)
    {
        app.MapGet("/secure", [Authorize] () => "You are logged in!")
           .RequireAuthorization();
    }
}
}