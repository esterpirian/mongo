using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherPro.General;

using System;

using WeatherPro.Services;

namespace WeatherPro
{
    public class Startup
    {

        #region Attributes
        public IConfiguration Configuration { get; }
       // readonly AppConfig cfg;
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           // cfg = configuration.Get<AppConfig>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRouting(x =>
             x.LowercaseUrls = true
             );
           
          
         services.AddHttpClient<IWeather, WeatherService>();
     services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddSingleton<WebAsyncActionFilter>();
       services.AddHttpClient<IHeader, HeaderService>();
           // Site.StoreSettings = cfg.StoreSettings;

            // services.AddStackExchangeRedisCache(o =>
            // {
            //     o.Configuration = cfg.Redis.Configuration;
            //     o.InstanceName = cfg.Redis.InstanceName;
            // });

           

            // services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //     .AddCookie(o =>
            //     {
            //         o.LoginPath = "/Account/SignIn";
            //         o.AccessDeniedPath = "/Account/Forbidden";
            //         o.Cookie.Name = ".hildenco.session";
            //     });

            // allow auto-rebuilding the cshtml after changes (dev-only)
            // https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.0#runtime-compilation
            #if DEBUG
         //   services.AddControllersWithViews().AddRazorRuntimeCompilation();
            #endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpContextItemsMiddleware();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
         
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
