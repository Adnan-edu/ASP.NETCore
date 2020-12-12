using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore
{
    public class Startup
    {
 /*       The constructor receives an IConfiguration object through its
constructor and assigns it to the Configuration property, which is used to access the connection string.*/
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        /*The IConfiguration interface provides access to the ASP.NET Core configuration system, which includes the contents of the
appsettings.json file*/
        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
/*            Entity Framework Core is configured with the AddDbContext method, which registers the database context class and configures
the relationship with the database.The UseSQLServer method declares that SQL Server is being used and the connection string is
read via the IConfiguration object.*/ 
            services.AddDbContext<StoreDbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:SportsStoreConnection"]);
            });
/*            The AddScoped method creates a service where each HTTP request gets its own repository object, which is the way that Entity
Framework Core is typically used.*/
            services.AddScoped<IStoreRepository, EFStoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
