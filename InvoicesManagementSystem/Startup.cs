using AutoMapper;
using InvoiceManagementSystem.Data;
using InvoiceManagementSystem.Helpers;
using InvoiceManagementSystem.Interfaces;
using InvoicesManagementSystem.Data;
using InvoicesManagementSystem.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem
{
    public class Startup
    {

        private IConfiguration _config;
        private readonly InvoiceManagementContext _context;
        readonly string _specifigOrigin = "_specificOrigin";
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<InvoiceManagementContext>(options => options.UseSqlServer(_config.GetConnectionString("InvoiceManagementConnectionString")));
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IDetaliiFacturaRepository, DetaliiFacturaRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddCors(o =>
            {
                o.AddPolicy("_specificOrigin",
                p => p.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_specifigOrigin);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<InvoiceManagementContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
