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
namespace Web.Controllers
{
   
   
    [ApiController]
    [Route("[controller]")]
    public class UserRegisterController : ControllerBase
    {
       
        readonly IUserRegister _svc;

        
        private readonly ILogger<UserRegisterController> _logger;

        public UserRegisterController(ILogger<UserRegisterController> logger,IUserRegister svc)
        {
            _logger = logger;
            _svc=svc;
         
        }
       
        [HttpPost] 
        [Route("[action]")]
         
           public async Task<IsRegister> signin([FromBody] UserRegister user) {
             
                
          
           return await _svc.Signin(user);
            
         }
        [HttpPost] 
        [Route("[action]")]
         
           public async Task<UserRegister> getuser([FromBody] UserRegister user) {
           return await _svc.GetUser(user);
            
         }
    }
}
