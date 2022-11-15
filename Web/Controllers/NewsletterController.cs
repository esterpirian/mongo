using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.DTO;
using Web.Services;

namespace Web.Controllers
{
   
   
     [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        readonly INewsletterProxy _svc;

        
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,INewsletterProxy svc)
        {
            _logger = logger;
            _svc=svc;
         
        }
       
        [HttpGet] 
        [Route("[action]")]
         
           public async Task<List<Meet>> signup() {
              var signup=  new Meet{
               Id=3,
               Name="kkk",
               inMeeating= new MeetIn [1].Select(h => new MeetIn{
                    addess="klh 78",
                    city="jer",
                    desc="jjj",
                    startDate=DateTime.Now,
endDate=DateTime.Now.AddDays(1)
               }).ToList()
              };
              
                
          
           return await _svc.Signup(signup);
            
         }
           [HttpGet] 
        [Route("[action]")]
         
           public async Task<List<Meet>> updateMe() {
              var signup=  new Meet{
               Id=2,
               Name="boaz",
               inMeeating= new MeetIn [1].Select(h => new MeetIn{
                    addess="klh 78",
                    city="jer",
                    desc="jjj",
                    startDate=DateTime.Now,
endDate=DateTime.Now.AddDays(1)
               }).ToList()
              };
              
                
          
           return await _svc.UpdateList(signup);
            
         }
    }
}
