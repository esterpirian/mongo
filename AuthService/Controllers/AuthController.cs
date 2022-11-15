using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using data.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Http;

namespace AuthService.Controllers
{
      [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
   
         private readonly InUserService _inuserService;
        
              
       
        public AuthController(ILogger<AuthController> logger,InUserService inuserService)
        {
            _logger = logger;
        
            _inuserService=inuserService;
           
           
            
        }

        [HttpGet]
        [Route("[action]")]
       
         public async Task<UserLogin> GetUser()=> await    Task.FromResult<UserLogin>( _inuserService.GetUser());
           
     
        [HttpGet]
        [Route("[action]")]
       
         public async Task<SecurityToken> GetUserByName(string name)
         {
               var user= await Task.FromResult<UserLogin>( _inuserService.GetUser());
               var sec=new SecurityToken(){auth_token=user.userName==name?user.auth_token:" "};
               return  await Task.FromResult<SecurityToken>(sec);

           }//=> await    Task.FromResult<UserLogin>( _inuserService.GetUser().userName==name?);
        
       
      
    }
}
