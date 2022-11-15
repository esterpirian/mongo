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
using webapi.data;
using webapi.DTO;
using data.Models;
using RegisterService.Services;
namespace RegisterService
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
             services.Configure<AppSettings>(options =>
            {
                options.Secret = Configuration.GetSection("AppSettings:Secret").Value;
               
            });
            services.AddSingleton<UserService>();
            services.AddSingleton<AccountService>();
            services.AddSingleton<InUserService>();
            services.AddSingleton<inRegisterService>();
            
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

          
             app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
        }
    }
}
