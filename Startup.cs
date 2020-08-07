using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Youkozi.Models;
using Microsoft.EntityFrameworkCore;

namespace Youkozi
{
    public class Startup
    {
        private const string AllCors = "All";
        private string _FinnhubKey = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddControllers();

            services.AddCors(options => options.AddPolicy("All", build => build.AllowAnyHeader()
                                                                    .AllowAnyOrigin()
                                                                    .AllowAnyMethod()));

            //services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Dev"));

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddHttpClient("weather", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/");
            });

            services.AddHttpClient("finnHub", client =>
            {
                client.BaseAddress = new Uri("https://finnhub.io/api/v1/");
                client.DefaultRequestHeaders.Add("X-Finnhub-Token", Configuration["finnHubKey"]);
            });

            //services.AddIdentity<User, IdentityRole<int>>(config =>
            //    {
            //        config.Password.RequiredLength = 5;
            //        config.Password.RequireDigit = false;
            //        config.Password.RequireNonAlphanumeric = false;
            //        config.Password.RequireUppercase = false;
            //        config.SignIn.RequireConfirmedEmail = false;
            //        config.SignIn.RequireConfirmedAccount = false;
            //    })
            //    .AddEntityFrameworkStores<DataContext>()
            //    .AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllCors);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
