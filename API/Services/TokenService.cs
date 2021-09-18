using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        //one key is used to both encryt and decrypt JSON webtoken uses Symmetric
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            //TokenKey set in appsetting.Development.json
            //should be set to at least a 332 character unguessable randowm string
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            //Adding some claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            //Creating credentials
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            //Describing how the token will look
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            //The token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            
            //Create the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            //Return the written token
            return tokenHandler.WriteToken(token);
        }
    }
}
