using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using SigfazCore.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace SigfazCore
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
                 services.AddDbContext<SigfazCoreContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("SigfazConect")));

            services.AddCors(options =>
            {
                options.AddPolicy("fiver",
                    policy => policy.WithOrigins("http://localhost:4200"));
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("fiver"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
