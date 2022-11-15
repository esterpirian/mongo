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

    public interface IinRegisterService
    {
        data.Models.SecurityToken CreateToken(UserRegister user);
        Boolean GetToken(string token,string password);
    }

    public class inRegisterService : IinRegisterService
    {
        
        private readonly AppSettings _appSettings;
        public inRegisterService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public data.Models.SecurityToken CreateToken(UserRegister user)
        {
           if (user == null)
                return null;

            // authentication successful so generate jwt token
           

            return new data.Models.SecurityToken() { auth_token = BCrypt.Net.BCrypt.HashPassword(user.passwprd) };
        }
        public Boolean GetToken (string token,string password){
            return BCrypt.Net.BCrypt.Verify(password,token);

        }
             
    }
}

