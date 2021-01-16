using DigitArc.ProductModule.Business.Logic;
using DigitArc.ProductModule.DataAccess.EntityFramework;
using DigitArc.ProductModule.DataAccess.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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
            services.AddControllers();

            //var dbConnectintion = services.Configure<AppSettingsModel>(Configuration.GetSection("DefaultConnection"));

            //services.AddDbContext<ProductModuleDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(aa.ToString()), b => b.MigrationsAssembly("DigitArc.ProductModule.WebApiService")));

            services.AddTransient<IProductModuleservice, ProductModuleManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}