using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using MenuTv.Entities;
using MenuTv.Repositories;

namespace MenuTv
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
            services.AddMvc(o =>
            {
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    value => Configuration["ValueMustNotBeNullMessage"]);
            });
            services.AddEntityFrameworkSqlite()
                .AddDbContext<BeerContext>((DbContextOptionsBuilder builder) =>
                {
                    builder.UseSqlite(Configuration["ConnectionString"]);
                });
            services.AddTransient<BeerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Edit}/{action=Index}/{id?}");
            });
        }
    }
}
