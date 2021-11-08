using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Application.Wrappers;

namespace Sat.Recruitment.Application.Interfaces
{
    /// <summary>
    /// Related with jwt token methods
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate the auth result with access token if succeed base on identity-user provided
        /// </summary>
        /// <param name="newUser">The user to validate to get a new jwt access token</param>
        /// <returns>Auth result with token if succeed or validation error message if not</returns>
        AuthenticationResult GenerateAuthResult(IdentityUser newUser);
    }
}
