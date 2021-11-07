using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Infra.AppConfiguration;
using Sat.Recruitment.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sat.Recruitment.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptionsMonitor<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.CurrentValue;
        }

        public AuthenticationResult GenerateAuthResult(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("d")),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id),
                    new Claim("createdAt", DateTimeHelper.GetSystemDate().ToString()),
                }),
                Expires = DateTimeHelper.GetSystemDate().AddHours(Convert.ToInt32(_jwtSettings.ValidHours)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult(tokenHandler.WriteToken(token), new List<string>());
        }

    }
}
