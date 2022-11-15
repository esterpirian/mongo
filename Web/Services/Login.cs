
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
    public class LoginService : 
        ProxyBase<LoginService>,
        ILogin
    {
        public LoginService(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<LoginService> logger,
              IHttpContextAccessor context,
            IDistributedCache cache) :
            base(httpClient, cfg, logger, cache,context)
           
        {

        }

        
         public async Task<UserFind> Signin(UserLogin user)=>
         await PostAsync<UserFind>("login", user, "/Login/Signin");
        
         public async Task<UserFind> GetData()=>
           await GetAsync<UserFind>("","", "http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=9c9e635a17ecd4932f32af1b666fe149");
    }
}
