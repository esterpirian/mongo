
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
using Microsoft.AspNetCore.Http;
using webapi.DTO;
namespace Web.Services
{
    public class NewsletterProxy : 
        ProxyBase<NewsletterProxy>,
        INewsletterProxy
    {
        public NewsletterProxy(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<NewsletterProxy> logger,
               IHttpContextAccessor context,
            IDistributedCache cache) :
            base(httpClient, cfg, logger, cache,context)
        {

        }

        
         public async Task<List<Meet>> Signup(Meet meet)=>
         await PostAsync<List<Meet>>("signup", meet, "/WeatherForecast/xxx");
          public async Task<List<Meet>> UpdateList(Meet meet)=>
         await PostAsync<List<Meet>>("signup", meet, "/WeatherForecast/UpdateList"); 
        
    }
}
