using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Functional.DotNet;
using Csharp.Functional.MinimalApi.Sample.Infra.Models;

namespace Csharp.Functional.MinimalApi.Sample.Api.Endpoints
{
    using static Csharp.Functional.MinimalApi.Sample.Extensions.ResultExt;

    public static class AuthEndpoints
    {
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            MapEndpoints(app.MapGroup("/api/v1/auth"));
            return app;
        }

        private static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/login", Login)
                .WithName("Login")
                .WithOpenApi();
        }

        public static async Task<IResult> Login([FromBody] LoginRequest loginModel, 
                                                [FromServices] UserManager<User> userManager, 
                                                [FromServices] JwtSettings jwtSettings) => await
            userManager.FindByEmailAsync(loginModel.Email).Map(
                Faulted: BadRequestWithLog, // It the task throws an exception we can handler here
                Completed: (userResult) => userResult.AsOption().Match( // In case of the task be completed with success we can get the user and part to Option to check if it is None (Null) or Some
                    None: Results.Unauthorized, //In case of None we can return Unauthorized
                    Some: (user) => LogedIn(user, jwtSettings))); // If we have some we can procced to Login (Return token)
        // We can see that is easy to read the flow of everything here, It will find by email if it fails it will return badrequest and log
        // Otherwise it will Check if none returns Unauthorized (because it means that we have no user with this user and pass) and 
        // if it is Some it will get the token and return
            
        private static IResult LogedIn(User user, JwtSettings jwtSettings) 
        {
            var token = GenerateJwtToken(user, jwtSettings); 
            return Results.Ok(new { Token = token });
        }

        private static string GenerateJwtToken(User user, JwtSettings jwtSettings)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                     // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}