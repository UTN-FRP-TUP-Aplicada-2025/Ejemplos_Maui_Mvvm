using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Validation;
using System.Security.Claims;

namespace Ejemplo_WebAPI_Encuestas.Identity;

class CustomProfileService : IResourceOwnerPasswordValidator, IProfileService
{
    private readonly IUserService _userService;

    public CustomProfileService(IUserService userService)
    {
        _userService = userService;
    }

    //public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    //{
    //    var user = _userService.Validate(context.UserName, context.Password);

    //    if (user != null)
    //    {
    //        context.Result = new GrantValidationResult(
    //            user.Id,
    //            "password",
    //                new List<Claim>
    //            {
    //                new Claim("role", user.Role),
    //                new Claim("name", user.Username)
    //            });
    //    }

    //    return Task.CompletedTask;
    //}

    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var user = _userService.Validate(context.UserName, context.Password);

        if (user == null)
        {
            context.Result = new GrantValidationResult( TokenRequestErrors.InvalidGrant, "Usuario o contraseña inválidos");
            return Task.CompletedTask;
        }

        context.Result = new GrantValidationResult(
            subject: user.Id,
            authenticationMethod: "password",
            claims: new List<Claim>
            {
            new Claim("role", user.Role),
            new Claim("name", user.Username)
            });

        return Task.CompletedTask;
    }

    //public Task GetProfileDataAsync(ProfileDataRequestContext context)
    //{
    //    return Task.CompletedTask;
    //}

    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var claims = context.Subject.Claims.ToList();
        context.IssuedClaims.AddRange(claims);
        return Task.CompletedTask;
    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive = true;
        return Task.CompletedTask;
    }
}
