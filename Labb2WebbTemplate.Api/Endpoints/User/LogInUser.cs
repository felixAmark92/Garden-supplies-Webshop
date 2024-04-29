using System.Security.Claims;
using FastEndpoints;
using FastEndpoints.Security;
using Labb2WebbTemplate.Shared;
using Labb2WebbTemplate.Shared.Dtos.UserDtos;
using Labb2WebbTemplate.StoreDataAccess;
using Microsoft.AspNetCore.Identity.Data;

namespace Labb2WebbTemplate.Api.Endpoints.User;

public class LogInUser(UnitOfWork unit) : Endpoint<AuthenticateUserRequest, string>
{
    public override void Configure()
    {
        Post("/Login");
        Group<UserGroupAnonymous>();
    }

    public override async Task HandleAsync(AuthenticateUserRequest req, CancellationToken ct)
    {
        var user = await unit.Users.GetByEmailAsync(req.Email);
        if (user is null)
        {
            AddError(ErrorMessages.WrongEmailOrPassword);
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        var hash = Cryptography.CreateSha256Hash(req.Password, user.Salt);

        if (!user.Hash.SequenceEqual(hash))
        {
            AddError(ErrorMessages.WrongEmailOrPassword);
            await SendErrorsAsync(cancellation: ct);
            return;
        }
        
        var jwtToken = JWTBearer.CreateToken(
            "fg2gfsuoyq74ogfoqGS7o8GFOyHEHL#UWO/#(ODDHEILWYOFGyrgfghKGHJKGhjkgYKGyKGRKgyKUG", 
            DateTime.Now.AddDays(3),
            ["user"],
            user.IsAdmin ? ["user", "admin"] : ["user"],
            new List<Claim>(){new Claim("userId", user.Id.ToString())},
            $"{user.Id}"
        );

        await SendOkAsync(jwtToken, ct);
    }
}















