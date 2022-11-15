using Microservices.Core.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using data.Models.coor;
using System.Xml.Linq;

namespace WeatherPro.Infrastructure.Base
//namespace WeatherPro.Infrastructure.Base
{
    public abstract class ProxyBase<T>
    {

        readonly ILogger<T> _logger;
        readonly HttpClient _httpClient;
                     private IHttpContextAccessor _context;
        readonly IDistributedCache _cache;
        readonly string _svcName = typeof(T).Name;
        readonly string _keyFmt;
        readonly string _host;
        protected DistributedCacheEntryOptions cacheOptions;

        private enum RequestType
        {
            Get,
            Post,
            Put,
            Delete,
            Soap
        }

        public ProxyBase(
            HttpClient httpClient,
            IConfiguration cfg,
            ILogger<T> logger,
            IDistributedCache cache,
            IHttpContextAccessor context)
        {
            _logger = logger;
            _httpClient = httpClient;
            _cache = cache;
_context = context ?? throw new ArgumentNullException(nameof(context));
            var name = _svcName.Replace("Proxy", "");
            _keyFmt = $":{name.ToLower()}:{{0}}:{{1}}";

            _host = cfg[$"Services:{name}"];
        }

        protected async Task<TResult> GetAsync<TResult>(string key, string val, string endpoint)
        {
            //var cacheKey = GetCacheKey(key, val);
           // var data = await _cache.GetStringAsync(cacheKey);
           // if (!data.HasValue())
           // {
                var url = $"{_host}{endpoint}";
             
                Log($"GET {key} '{val ?? "*"}' from: '{url}'");

                var resp = await _httpClient.GetAsync(url);
               var  data = await resp.Content.ReadAsStringAsync();
                
                

            var objData= JsonConvert.
                DeserializeObject<TResult>(data);
                return objData;
        }

        protected async Task<TResult> PostAsync<TResult>(string key, object val, string endpoint)
        {
            var resp = await RequestAsync(key, val, endpoint, RequestType.Post);
            var content = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(content);
        }

        protected async Task<HttpStatusCode> PostAsync(string key, object val, string endpoint)
        {
            return (await RequestAsync(key, val, endpoint, RequestType.Post))
                .StatusCode;
        }

        protected async Task<HttpStatusCode> PutAsync(string key, object val, string endpoint)
        {
            return (await RequestAsync(key, val, endpoint, RequestType.Put))
                .StatusCode;
        }

        protected async Task<HttpStatusCode> DeleteAsync(string key, string endpoint)
        {
            return (await RequestAsync(key, null, endpoint, RequestType.Delete))
                .StatusCode;
        }

        private async Task<HttpResponseMessage> RequestAsync(
            string key, 
            object val, 
            string endpoint, 
            RequestType rt)
        {
            var url = $"{_host}{endpoint}";
            Log($"{rt.ToString().ToUpper()} {key} to: {url}");

            var data = new StringContent(
                JsonConvert.SerializeObject(val),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage resp = null;
           switch (rt)
            {
                case RequestType.Post:
                    resp = await _httpClient.PostAsync(url, data);
                    break;
                case RequestType.Put:
                    resp = await _httpClient.PutAsync(url, data);
                    break;
                case RequestType.Delete:
                    resp = await _httpClient.DeleteAsync(url);
                    break;
                default:
                    throw new NotImplementedException();
            }

            var msg = $"Response for '{key}' was: {resp.StatusCode} / {resp.ReasonPhrase}";
            Log(msg);

            if (!resp.IsSuccessStatusCode)
            {
                _logger.LogError($"[{_svcName}] {msg}. Error: {resp.ReasonPhrase}");
            }
         
 
            return resp;
        }
protected async Task<string> AddNumbersAsync(string body,string url)
{
   // var soapString = this.ConstructSoapRequest(500);
    using (var client = new HttpClient())
    {
        client.DefaultRequestHeaders.Add("SOAPAction",url);//, "https://www.dataaccess.com/webservicesserver/NumberConversion.wso");
        var content = new StringContent(body, Encoding.UTF8, "text/xml");
        using (var response = await client.PostAsync(url, content))
        {
            var soapResponse = await response.Content.ReadAsStringAsync();
            return soapResponse;//this.ParseSoapResponse(soapResponse);
        }
    }
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
        protected string GetCacheKey(string cat, string id)
        {
            return _keyFmt.FormatWith(cat, id);
        }

        protected void Log(string msg)
        {
            _logger.LogDebug($"[{_svcName}] {msg}");
        }
       
    }
}
