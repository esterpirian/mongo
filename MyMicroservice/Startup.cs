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

namespace MyMicroservice
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
             services.Configure<MeetStoreDatabaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MeetStoreDatabase:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MeetStoreDatabase:DatabaseName").Value;
                options.MeetsCollectionName=Configuration.GetSection("MeetStoreDatabase:BooksCollectionName").Value;
            });
            services.AddSingleton<MeetsService>();
             services.Configure<SPDatabaseSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MeetStoreDatabase:ConnectionString").Value;
                options.DatabaseName = Configuration.GetSection("MeetStoreDatabase:DatabaseName").Value;
                options.SPCollectionName=Configuration.GetSection("MeetStoreDatabase:spCollection").Value;
            });
            services.AddSingleton<SPService>();
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
