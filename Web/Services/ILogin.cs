using System.Threading.Tasks;
using webapi.DTO;
using System.Collections.Generic;
using System;
using data.Models;
namespace Web.Services
{
    public interface ILogin
    {
    
        Task<UserFind> Signin(UserLogin user);
       Task<UserFind> GetData();
    }
}