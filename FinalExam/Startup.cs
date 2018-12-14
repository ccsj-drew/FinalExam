using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExam.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FinalExam { 

    public class Startup {  

    public  Startup(IConfiguration configuration) =>
        Configuration= configuration;

        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
             Configuration["Data:FinalExamItems:ConnectionString"]));
            services.AddTransient<IItemRepository, EFItemRepository>();
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Item}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
