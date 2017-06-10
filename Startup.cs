using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnlineShop
{
    public class Startup
    {
        private IConfigurationRoot _configuration;
        private string pgsqlConnectionString;
        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json")
                            .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            pgsqlConnectionString = _configuration["Data:pgsqlConnectionString"];
            services.AddDbContext<AppDbContext>(options => 
                options.UseNpgsql(pgsqlConnectionString));
            // services.AddTransient<ICategoryRepository, InMemoryCategoryRepository>();
            // services.AddTransient<ITourRepository, InMemoryTourRepository>();
            // Commenting the above lines as we now use the DB repositories as below:
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITourRepository, TourRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<TourCart>(sp=>TourCart.Get(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "viewByCategory",
                    template: "Tours/{action}/{category?}",
                    defaults: new { controller = "Tours", action = "TourList"}
                );

                routes.MapRoute(
                    name: "default",
                    template:"{controller=Home}/{action=Index}/{id?}"
                );
            });

            DbInitializer.Seed(app);
            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
        }
    }
}
