
 // using Microsoft.AspNetCore.Mvc;
namespace Web.General
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
public class WebAsyncActionFilter : IAsyncActionFilter
{
     private IHttpContextAccessor _context;
     public WebAsyncActionFilter(IHttpContextAccessor context){
       _context=context;
     }
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // do something before the action executes_context.HttpContext.Request.Headers
       Console.WriteLine(_context.HttpContext.Request.Headers["nameUser"].ToString());
        var resultContext = await next();
//_context.HttpContext.Response.Headers.Add("loginToken",_context.HttpContext.Session.GetString("loginToken"));
  //Console.WriteLine(_context.HttpContext.Session.GetString("loginToken"));
//_context.HttpContext.Session.Clear();
// HttpContext.Session.SetString("loginToken",session.ToString()); 
        // do something after the action executes; resultContext.Result will be set
       // context.Result.
    }
}



}
