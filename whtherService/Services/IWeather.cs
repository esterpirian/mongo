using System.Threading.Tasks;

using System.Collections.Generic;
using System;
using data.Models;
using data.Models.coor;
using data.Models.city;
namespace WeatherPro.Services
{
    public interface IWeather
    {
    
        Task<RootObject> fetUserRep(cordGet user,String key);
       Task<RootObjCity> fetcityRep(String city,String key);
        Task<int> xxx();
    }
}