using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPTest.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERPTest
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
            //services.AddCors();
           // services.AddMvc();
            services.AddControllers();

            //Sign Database Connection
            services.AddDbContext<BuyerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BuyerCon"), b => b.MigrationsAssembly("ERPTest")));
            services.AddDbContext<AttributeDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AttributeCon"), b => b.MigrationsAssembly("ERPTest")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ///Binding with Clients
            //app.UseCors(options => options
            // .AllowAnyOrigin()
            //.WithOrigins("http://localhost:4200")
            //.AllowAnyMethod()
            //.AllowAnyHeader());


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
