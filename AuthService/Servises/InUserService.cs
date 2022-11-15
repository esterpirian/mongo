namespace AuthService.Services
{
    using data.Models;
    using Microsoft.Extensions.Options;
      using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    public interface IInUserService
    {
       UserLogin GetUser();

    }

    public class InUserService : IInUserService
    {
        
        private readonly UserLogin _appSettings;
        public InUserService(IOptions<UserLogin> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserLogin GetUser()
        {
            return new UserLogin(){userName=_appSettings.userName,auth_token=_appSettings.auth_token};
        }
       
      
    }
}

