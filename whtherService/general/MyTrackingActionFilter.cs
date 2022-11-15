
 // using Microsoft.AspNetCore.Mvc;
namespace WeatherPro.General
{
    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
// using System.Web.Http.Filters;
// using System.Web.Http.Controllers;
 using Microsoft.AspNetCore.Mvc.Filters;
 using WeatherPro.Services;
 using data.Models;
public class WebAsyncActionFilter : IAsyncActionFilter
{
     private IHttpContextAccessor _context;
        readonly IHeader _svc;
     public WebAsyncActionFilter(IHttpContextAccessor context,IHeader headerservice){
       _context=context;
       _svc=headerservice;
     }
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
          SecurityToken key=await _svc.getSecret(_context.HttpContext.Request.Headers["nameUser"].ToString());
      if(key.auth_token!=""){
         //_context.HttpContext.Session.SetString("key",key.auth_token);  
         _context.HttpContext.Request.Headers.Add("key",key.auth_token);
var resultContext = await next();
      }
      else{
        _context.HttpContext.Response.StatusCode = 401;
        return;
      }
        

    }
}



}
