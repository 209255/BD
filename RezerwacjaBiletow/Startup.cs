using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RezerwacjaBiletow.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace RezerwacjaBiletow
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
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            //services.AddAuthentication(sharedOptions =>
            // {
            //     sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options => {
            //    options.Authority = "	https://dev-731522.oktapreview.com/oauth2/default";
            //    options.Audience = "api://default";
            // });

            services.AddDbContext<RezerwacjaBiletowContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RezerwacjaBiletow")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            //app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
