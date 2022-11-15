using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webapi.DTO;
using data.Models;
using webapi.data;
using LoginService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using LoginService.General;

namespace LoginService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddControllers();
             services.Configure<UserbaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("UserStoreDatabase:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("UserStoreDatabase:DatabaseName").Value;
                options.UserCollectionName=Configuration.GetSection("UserStoreDatabase:UserCollectionName").Value;
            });
            services.Configure<AccountbaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("UserStoreDatabase:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("UserStoreDatabase:DatabaseName").Value;
                options.AccountCollectionName=Configuration.GetSection("UserStoreDatabase:AccountCollectionName").Value;
            });
             services.Configure<SessionbaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("UserStoreDatabase:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("UserStoreDatabase:DatabaseName").Value;
                options.SessionCollectionName=Configuration.GetSection("UserStoreDatabase:SessionCollectionName").Value;
            });
             services.Configure<AppSettings>(options =>
            {
                options.Secret = Configuration.GetSection("AppSettings:Secret").Value;
               
            });
      
            services.AddSingleton<UserService>();
            services.AddSingleton<AccountService>();
             services.AddSingleton<SessionService>();
            services.AddSingleton<InUserService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
             services.AddSingleton<LoginAsyncActionFilter>();
        //      services.AddDistributedMemoryCache();
        // services.AddSession(options => {
        //   options.IdleTimeout= TimeSpan.FromMinutes(10);
        //   }); 
        //   services.AddMvc();
      services.AddMvc(options => options.EnableEndpointRouting = false);
services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
              if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

          
            //  app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllerRoute(
            //         name: "default",
            //         pattern: "{controller}/{action}/{id?}");
            // });
          app.UseSession();

// Add MVC to the request pipeline.
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller}/{action}/{id?}");
});
        }
    }
}
