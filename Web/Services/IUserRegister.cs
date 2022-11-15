using System.Threading.Tasks;
using webapi.DTO;
using System.Collections.Generic;
using System;
using data.Models;
namespace Web.Services
{
    public interface IUserRegister
    {
    
        Task<IsRegister> Signin(UserRegister user);
        Task<UserRegister> GetUser(UserRegister user);
    }
}