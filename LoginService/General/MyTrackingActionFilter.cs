
 // using Microsoft.AspNetCore.Mvc;
namespace LoginService.General
{
    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;



using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
 using Microsoft.AspNetCore.Mvc.Filters;
public class LoginAsyncActionFilter : IAsyncActionFilter
{
     private IHttpContextAccessor _context;
     public LoginAsyncActionFilter(IHttpContextAccessor context){
       _context=context;
     }
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // do something before the action executes
        //Console.WriteLine("start");
        Console.WriteLine(_context.HttpContext.Request.Headers["nameUser"].ToString());
        var resultContext = await next();
_context.HttpContext.Response.Headers.Add("loginToken",_context.HttpContext.Session.GetString("loginToken"));
  Console.WriteLine(_context.HttpContext.Session.GetString("loginToken"));
_context.HttpContext.Session.Clear();
// HttpContext.Session.SetString("loginToken",session.ToString()); 
        // do something after the action executes; resultContext.Result will be set
       // context.Result.
    }
}

//   public class LogAttribute : Attribute, IActionFilter
//   {
//     public LogAttribute()
//     {
//       //var a = "";
//     }

//      //  private IHttpContextAccessor _context;

//     Task<HttpResponseMessage> IActionFilter.ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
//     {
//       //Trace.WriteLine(string.Format("Action Method {0} executing at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
//     //   if (actionContext.Request.Headers.GetValues("headerName").Count() > 0)
//     //   {
//     //     var a = "todo";
//     //   }
//       var result = continuation();

//       result.Wait();
//     //   if(actionContext.Request.Headers.GetValues("headerName").Count()>0)
//     //   {
//     //     // var cookies = new HttpCookie("ExApplicationSessionID", "ester");
//     //     // cookies.Expires = DateTime.Now.AddMinutes(6);
//     //     // cookies.HttpOnly = true;
        
//     //     // HttpContext..Response.AppendCookie(cookies);
//     //     // HttpContext.Current.Response.AddHeader("ApplicationSessionID","ester1");
//     //   }
//       //Trace.WriteLine(string.Format("Action Method {0} executed at {1}", actionContext.ActionDescriptor.ActionName, DateTime.Now.ToShortDateString()), "Web API Logs");
//          actionContext.Response.Headers.Add("ster","val");
//       return result;
//     }

//     public bool AllowMultiple
//     {
//       get { return true; }
//     }

//   //  bool IFilter.AllowMultiple => throw new NotImplementedException();
//   }

}
