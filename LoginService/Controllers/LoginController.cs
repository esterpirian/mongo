using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.data;
using webapi.DTO;
using data.Models;
using LoginService.Services;
using Microsoft.AspNetCore.Http;
using  LoginService.General;
namespace LoginService.Controllers
{
      [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UserService _userService;
         private readonly InUserService _inuserService;
            private readonly AccountService _accountService;
              private readonly SessionService _sessionService;
              
       
        public LoginController(ILogger<LoginController> logger,UserService userService,InUserService inuserService,AccountService accountService,SessionService sessionService)
        {
            _logger = logger;
            _userService=userService;
            _inuserService=inuserService;
            _accountService=accountService;
            _sessionService=sessionService;
           
            
        }

        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(LoginAsyncActionFilter))]
        public async Task<UserDetail> Signin([FromBody] UserLogin user) {
           // var pathBase = HttpContext.Request.PathBase;
             //Console.WriteLine("sinein");
            User isExist=await _userService.GetAsync(user.userName);
            if(isExist!=null){
                  //  Console.WriteLine(isExist.token);
                  //  Console.WriteLine(user.passwprd);
                   if (_inuserService.GetToken(isExist.token,user.passwprd)){
                            Console.WriteLine(user.passwprd);
                            
                       var data= await _accountService.GetAsync(user.userName);
                         await Task.Delay(3000);
                        Console.WriteLine(data.user);
                   Console.WriteLine(user.userName);
                       if(data!=null){
                         var token=_inuserService.CreateToken(data);
                         var session =Guid.NewGuid();
                         await _sessionService.CreateAsync(new Session{ user=user.userName,  token =token.auth_token, session=session.ToString(),userAgent=HttpContext.Request.Headers["UserAgent"],date=DateTime.Now});
                        
                        
                         HttpContext.Session.SetString("loginToken",session.ToString());  
                         return data;
                       }
                   }
                  
            }
            else 
               return null;
          return null;
           
        }
        
        
       
      
    }
}
