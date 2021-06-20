using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using MyKoloApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyKoloApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSettings;

        public TokenService(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            //key used for sigingCredentials
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //Create token using tokenDescriptor
            var createToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(createToken);

            return token;
        }
    }
}