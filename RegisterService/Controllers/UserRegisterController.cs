using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.data;
using webapi.DTO;
using data.Models;
using RegisterService.Services;
namespace RegisterService.Controllers
{
      [ApiController]
    [Route("[controller]")]
    public class UserRegisterController : ControllerBase
    {
        private readonly ILogger<UserRegisterController> _logger;
        private readonly UserService _userService;
         private readonly InUserService _inuserService;
            private readonly AccountService _accountService;
         private readonly inRegisterService _inRegisterService;
        public UserRegisterController(ILogger<UserRegisterController> logger,UserService userService,InUserService inuserService,AccountService accountService,inRegisterService inRegisterService)
        {
            _logger = logger;
            _userService=userService;
            _inuserService=inuserService;
            _accountService=accountService;
            _inRegisterService=inRegisterService;

            
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IsRegister> Signin([FromBody] UserRegister user) {
         
           var isExist=await Register(user);
           if(isExist==IsRegister.Success) {
                 var inuser=_inRegisterService.CreateToken(user);
                User data= new User{ user=user.userName, token=inuser.auth_token};
                await _userService.CreateAsync(data);
                UserDetail data1= new UserDetail{user=user.userName,currency=user.currency,idNumber=int.Parse(user.Id),account=int.Parse(user.Account)};
                await _accountService.CreateAsync(new UserDetail{user=user.userName,currency=user.currency,idNumber=int.Parse(user.Id),account=int.Parse(user.Account)});
                return IsRegister.Success;
           }
           else{
               return isExist;
           }
          
           
        }
        public async Task<IsRegister> Register( UserRegister user) {
             User isExist=await _userService.GetAsync(user.userName);
            if(isExist!=null){
                 
                   return _inRegisterService.GetToken(isExist.token,user.passwprd)?IsRegister.Exist:IsRegister.Error;
            }
            else 
               return IsRegister.Success;
        }
       
      
    }
}
