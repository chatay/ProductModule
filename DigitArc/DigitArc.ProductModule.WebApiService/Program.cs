using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace DigitArc.ProductModule.WebApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging(logging =>
            {
                // clear default logging providers
                logging.ClearProviders();

                // add built-in providers manually, as needed 
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventLog();
                logging.AddEventSourceLogger();
                logging.SetMinimumLevel(LogLevel.Trace);
            });
    }
}