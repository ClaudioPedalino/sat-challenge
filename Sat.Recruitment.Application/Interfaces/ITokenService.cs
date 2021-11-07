using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Application.Wrappers;

namespace Sat.Recruitment.Application.Interfaces
{
    public interface ITokenService
    {
        AuthenticationResult GenerateAuthResult(IdentityUser newUser);
    }
}
