using System.Threading.Tasks;

using System.Collections.Generic;
using System;
using data.Models;
namespace WeatherPro.Services
{
    public interface IHeader
    {
           Task<SecurityToken> getSecret(String name);
    }
}