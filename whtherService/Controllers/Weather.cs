using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherPro.Services;
using data.Models;
using WeatherPro.General;
using data.Models.coor;
using data.Models.city;
namespace WeatherPro.Controllers
{
   
   
    [ApiController]
    [Route("[controller]")]

    public class WeatherController : ControllerBase
    {
       
        readonly IWeather _svc;

        
        private readonly ILogger<WeatherController> _logger;
  private IHttpContextAccessor _context;
        public WeatherController(ILogger<WeatherController> logger,IWeather svc,IHttpContextAccessor context)
        {
            _logger = logger;
            _svc=svc;
          _context=context;
        }
       
        [HttpPost] 
        [Route("[action]")]
           [ServiceFilter(typeof(WebAsyncActionFilter))]
           public async Task<RootObject> fetUserRep([FromBody] cordGet user) {
             
             var x=_svc.xxx();
          
           return await _svc.fetUserRep(user,_context.HttpContext.Request.Headers["key"].ToString());
            
         }
            [HttpPost] 
        [Route("[action]")]
           [ServiceFilter(typeof(WebAsyncActionFilter))]
           public async Task<RootObjCity> fetcityRep([FromBody] cityGet city) {
             
                    //xxx();
          
           return await _svc.fetcityRep(city.city,_context.HttpContext.Request.Headers["key"].ToString());
            
         }
    }
}
    
//     public class RootObject
//     {
//         public double lat { get; set; }
//         public double lon { get; set; }
//         public string timezone { get; set; }
//         public int timezone_offset { get; set; }
//          public Current current { get; set; }
//              public List<Hourly> hourly { get; set; }
// 	public List<Daily> daily { get; set; }
//     }
// public class Current
//     {
//         public int dt { get; set; }
//         public int sunrise { get; set; }
//         public int sunset { get; set; }
//         public double temp { get; set; }
//         public double feels_like { get; set; }
//         public int pressure { get; set; }
//         public int humidity { get; set; }
//         public double dew_point { get; set; }
//         public double uvi { get; set; }
//         public int clouds { get; set; }
//         public int visibility { get; set; }
//         public double wind_speed { get; set; }
//         public int wind_deg { get; set; }
//         public double wind_gust { get; set; }
//       public List<Weather> weather { get; set; }
//     }
// public class Weather
//     {
//         public int id { get; set; }
//         public string main { get; set; }
//         public string description { get; set; }
//         public string icon { get; set; }
//     }
//  public class Hourly
//     {
//         public int dt { get; set; }
//         public double temp { get; set; }
//         public double feels_like { get; set; }
//         public int pressure { get; set; }
//         public int humidity { get; set; }
//         public double dew_point { get; set; }
//         public double uvi { get; set; }
//         public int clouds { get; set; }
//         public int visibility { get; set; }
//         public double wind_speed { get; set; }
//         public int wind_deg { get; set; }
//         public double wind_gust { get; set; }
//         public List<Weather> weather { get; set; }
//         public int pop { get; set; }
//     }
// public class Daily
//     {
//         public int dt { get; set; }
//         public int sunrise { get; set; }
//         public int sunset { get; set; }
//         public int moonrise { get; set; }
//         public int moonset { get; set; }
//         public double moon_phase { get; set; }
//         public Temp temp { get; set; }
//         public FeelsLike feels_like { get; set; }
//         public int pressure { get; set; }
//         public int humidity { get; set; }
//         public double dew_point { get; set; }
//         public double wind_speed { get; set; }
//         public int wind_deg { get; set; }
//         public double wind_gust { get; set; }
//         public List<Weather> weather { get; set; }
//         public int clouds { get; set; }
//         public double pop { get; set; }
//         public double uvi { get; set; }
//     }
//  public class Temp
//     {
//         public double day { get; set; }
//         public double min { get; set; }
//         public double max { get; set; }
//         public double night { get; set; }
//         public double eve { get; set; }
//         public double morn { get; set; }
//     }
//  public class FeelsLike
//     {
//         public double day { get; set; }
//         public double night { get; set; }
//         public double eve { get; set; }
//         public double morn { get; set; }
//     }

