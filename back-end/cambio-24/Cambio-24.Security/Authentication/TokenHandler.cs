using Cambio_24.Domain.Entities;
using Cambio_24.Models.AuthenticationModels;
using Cambio_24.Security.Config;
using Cambio_24.Security.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Cambio_24.Security.Authentication
{
    public class JwtHandler : IJwtHandler
    {
        public string GenerateToken(UserEntity user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secret));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimEnum.UserId, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.Now.AddHours(JwtConfig.ExpireIn),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthenticationModel GetTokenContent(string token)
        {
            var authenticationModel = new AuthenticationModel();

            try
            {
                var stream = token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(stream);
                var tokenContent = handler.ReadToken(stream) as JwtSecurityToken;

                authenticationModel.UserId = tokenContent.Claims.First(claim => claim.Type == ClaimEnum.UserId).Value;

            }
            catch (Exception)
            {
                authenticationModel = null;
            }

            return authenticationModel;
        }
    }
}

