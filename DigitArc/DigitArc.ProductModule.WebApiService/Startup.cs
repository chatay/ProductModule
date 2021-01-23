using DigitArc.ProductModule.Business.Logic;
using DigitArc.ProductModule.Business.MessageHandler;
using DigitArc.ProductModule.DataAccess.DatabaseLogic;
using DigitArc.ProductModule.DataAccess.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics;
using static DigitArc.ProductModule.Business.MessageHandler.RequestResponseLoggingMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using DigitArc.ProductModule.WebApiService.Controllers;

namespace DigitArc.ProductModule.WebApiService
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddControllers();
            services.AddDbContext<ProductModuleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IProductModuleservice, ProductModuleManager>();
            services.AddTransient<IProductRepository, ProductDal>();

            services.AddSingleton<ILogger>(svc => svc.GetRequiredService<ILogger<ProductController>>());
            services.AddLogging(builder => builder.SetMinimumLevel(LogLevel.Trace));

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.Use(async (context, next) => {
            //    context.Request.EnableBuffering();
            //    await next();
            //});
            //app.UseRequestResponseLogging();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}