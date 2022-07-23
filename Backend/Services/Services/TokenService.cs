﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    /// <summary>
    /// Responsible for generating tokens using JWT
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
        }


        /// <summary>
        /// Creates Token
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roles"></param>
        /// <param name="roleManager"></param>
        /// <returns></returns>
        public async Task<SecurityToken> CreateToken(ApplicationUser user, IList<string> roles,
            RoleManager<ApplicationRole> roleManager)
        {
            // define claims

            // user claim
            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                };


            // role claim
            foreach (var item in roles)
            {
                var roe = await roleManager.FindByNameAsync(item.ToString());
                authClaims.Add(new Claim(ClaimTypes.Role, roe.Id.ToString()));
            }

            // define signincredentials (encryption algorithm)
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // define token descriptor (how token is going to look)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };


            // define token handler & token
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // return written token
            return token;
        }


        public int VerifyToken(string auth)
        {
            //string token = auth.Substring(7);
            //var tokenHandler = new JwtSecurityTokenHandler();
            //tokenHandler.ValidateToken(token, new TokenValidationParameters
            //{
            //ValidateIssuerSigningKey = true,
            //IssuerSigningKey = _key,
            //ValidateIssuer = false,
            //ValidateAudience = false,
            //ClockSkew = TimeSpan.Zero,

            //}, out SecurityToken validatedToken);

            //var jwtToken = (JwtSecurityToken)validatedToken;

            //var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
            //var roleId = int.Parse(jwtToken.Claims.First(x => x.Type == "role").Value);
            //return userId;
            return 0;
        }
}
}