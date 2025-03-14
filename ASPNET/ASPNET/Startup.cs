using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Logic;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => opt.EnableEndpointRouting = false).AddRazorRuntimeCompilation();
            services.AddTransient<IRepository<Driver>, DriversRepository>();
            services.AddTransient<IRepository<Team>, TeamRepository>();
            services.AddTransient<IRepository<League>, LeagueRepository>();
            services.AddTransient<DriverLogic, DriverLogic>();
            services.AddTransient<TeamLogic, TeamLogic>();
            services.AddTransient<LeagueLogic, LeagueLogic>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
            app.UseRouting();
            app.UseStaticFiles();
            
        }
    }
}
