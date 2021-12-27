using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleApplication.Models.Repos;
using PeopleApplication.Models.Services;
using PeopleApplication.Controllers;
using Microsoft.EntityFrameworkCore;
using PeopleApplication.Models;

namespace PeopleApplication
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
            services.AddDbContext<PeopleContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
           // services.AddScoped<IpeopleRepo, InMemoryPeopleRepo>();//Ioc& DI
            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();//Ioc& DI
            services.AddScoped<ICountryRepo, CountryRepo>();//Ioc& DI
            services.AddScoped<ICityRepo, CityRepo>();//Ioc& DI
            services.AddScoped<IPeopleService, PeopleService>();//Ioc&DI
            services.AddScoped<ICountryService, CountryService>();//Ioc&DI
            services.AddScoped<ICityService, CityService>();//Ioc&DI

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Person}/{action=ShowAllPeople}/{id?}");
            });
        }
    }
}
