
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Web.Infrastructure.Base;
using Microsoft.Extensions.Caching.Distributed;
using webapi.DTO;
using data.Models;
using Microsoft.AspNetCore.Http;
namespace Web.Services
{
    public class UserRegisterService : 
        ProxyBase<UserRegisterService>,
        IUserRegister
    {
        public UserRegisterService(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<UserRegisterService> logger,
               IHttpContextAccessor context,
            IDistributedCache cache) :
            base(httpClient, cfg, logger, cache,context)
        {

        }

        
         public async Task<IsRegister> Signin(UserRegister user)=>
         await PostAsync<IsRegister>("register", user, "/UserRegister/Signin");
          public async  Task<UserRegister> GetUser(UserRegister user)=>
         await PostAsync<UserRegister>("register", user, "/UserRegister/GetUser"); 
        
    }
}
