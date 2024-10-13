using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Entites.identityAppUser;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.TokenServices
{

    public class TokenService : ITokenService
    {
        
        
        
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }
        public string GenerateToken(AppUser appUser)
        {
            try
            {


                var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Email , appUser.Email),
                new Claim(ClaimTypes.GivenName , appUser.DisplayName),
                new Claim("UserId", appUser.Id),
                new Claim("UserName", appUser.UserName)


            };

                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(claim),
                    SigningCredentials = creds,
                    Issuer = _configuration["Token:Issuer"],
                    IssuedAt = DateTime.Now,
                    Expires = DateTime.Now.AddDays(1),


                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);


                return tokenHandler.WriteToken(token);



            }
            catch (Exception ex) 
            {
                throw new Exception("Error in token");
            
            }
        }
        

    }
}
