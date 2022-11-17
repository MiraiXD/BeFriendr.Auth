using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BeFriendr.Auth.Authentication.Helpers;
using BeFriendr.Auth.Authentication.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BeFriendr.Auth.Authentication.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly AuthenticationSettings _authenticationSettings;
        public JwtTokenService(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.SecretKey));
        }
        public string CreateToken(List<Claim> claims)
        {
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(_authenticationSettings.ExpiresInMinutes),
                SigningCredentials = credentials,
                Issuer = _authenticationSettings.Issuer,
                Audience = _authenticationSettings.Audience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}