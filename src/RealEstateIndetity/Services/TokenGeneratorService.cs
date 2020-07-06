namespace RealEstateIndetity.Services
{
    using RealEstateIndetity.Common;
    using Microsoft.Extensions.Options;
    using RealEstateIndetity.Models;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using System.Security.Claims;
    using System.Linq;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using Microsoft.Extensions.Configuration;

    public class TokenGeneratorService : ITokenGeneratorService
    {

        public IConfiguration Configuration { get; }

        public TokenGeneratorService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GenerateToken(User user, IEnumerable<string> roles = null)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("ApplicationSettings").GetValue<string>("Secret"));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email)
            };

            if (roles != null)
            {
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
