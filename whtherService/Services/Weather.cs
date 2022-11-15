
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using WeatherPro.Infrastructure.Base;
using Microsoft.Extensions.Caching.Distributed;
using System.Xml.Linq;
using data.Models;
using data.Models.coor;
using data.Models.city;
using Microsoft.AspNetCore.Http;
namespace WeatherPro.Services
{
    public class WeatherService : 
        ProxyBase<WeatherService>,
        IWeather
    {
        public WeatherService(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<WeatherService> logger,
              IHttpContextAccessor context,
            IDistributedCache cache) :
            base(httpClient, cfg, logger, cache,context)
           
        {

        }

        
         public async Task<RootObject> fetUserRep(cordGet user,String key)=>
         await GetAsync<RootObject>("whether", "", "/data/2.5/onecall?APPID="+key+"&lat="+user.lat+"&lon="+user.lon);
        
         public async Task<RootObjCity> fetcityRep(String city,String key)=>
           await GetAsync<RootObjCity>("whether","", "/data/2.5/weather?q="+city+"&APPID="+key);
           public async Task<int> xxx(){
             var st=await AddNumbersAsync(ConstructSoapRequest(500),"https://www.dataaccess.com/webservicesserver/NumberConversion.wso");
             return ParseSoapResponse(st);
           }
           
           private string ConstructSoapRequest(int a)
{
    return String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
  <soap:Body>
    <NumberToWords xmlns=""http://www.dataaccess.com/webservicesserver/"">
      <ubiNum>{0}</ubiNum>
    </NumberToWords>
  </soap:Body>
</soap:Envelope>", a);
}

private int ParseSoapResponse(string response)
{
    var soap = XDocument.Parse(response);
    XNamespace ns = "http://www.dataaccess.com/webservicesserver/";
    var result = soap.Descendants(ns + "NumberToWordsResponse").First().Element(ns + "NumberToWordsResult").Value;
    //return Int32.Parse(result);
    return 0;
}
    }
}
