namespace RegisterService.Services
{
    using data.Models;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    public interface IInUserService
    {
        data.Models.SecurityToken CreateToken(UserRegister user);
    
    }

    public class InUserService : IInUserService
    {
        
        private readonly AppSettings _appSettings;
        public InUserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public data.Models.SecurityToken CreateToken(UserRegister user)
        {
           if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userName", user.userName),
                    new Claim("passwprd", user.passwprd),
                    new Claim("Id", user.Id),
                    new Claim("Account",user.Account)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtSecurityToken = tokenHandler.WriteToken(token);

            return new data.Models.SecurityToken() { auth_token = jwtSecurityToken };
        }
    }   
}

