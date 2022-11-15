
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using WeatherPro.Infrastructure.Base;
using Microsoft.Extensions.Caching.Distributed;

using data.Models;
using Microsoft.AspNetCore.Http;
namespace WeatherPro.Services
{
    public class HeaderService : 
        ProxyBase<HeaderService>,
        IHeader
    {
        public HeaderService(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<HeaderService> logger,
              IHttpContextAccessor context,
            IDistributedCache cache) :
            base(httpClient, cfg, logger, cache,context)
           
        {

        }

        
         public async Task<SecurityToken> getSecret(String name)=>
         await GetAsync<SecurityToken>("AuthService",name, "/Auth/GetUserByName?name="+name);
        
        
    }
}
