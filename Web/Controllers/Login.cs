using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.DTO;
using Web.Services;
using data.Models;
using Web.General;
namespace Web.Controllers
{
   
   
    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
       
        readonly ILogin _svc;

        
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger,ILogin svc)
        {
            _logger = logger;
            _svc=svc;
         
        }
       
        [HttpPost] 
        [Route("[action]")]
           [ServiceFilter(typeof(WebAsyncActionFilter))]
           public async Task<UserFind> signin([FromBody] UserLogin user) {
             
                
          
           return await _svc.Signin(user);
            
         }
          [HttpGet] 
        [Route("[action]")]
           [ServiceFilter(typeof(WebAsyncActionFilter))]
           public async Task<UserFind> GetData() {
             
                
          
           return await _svc.GetData();
            
         }
        
    }
}
