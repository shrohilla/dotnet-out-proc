using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppDotnetOutProc
{
    public class Startup
    {
        public static async Task Main()
        {
            var builder = new HostBuilder()
               .UseEnvironment("Development")
               .ConfigureWebJobs(b =>
               {
                   b.AddKafka();
               })
               .ConfigureAppConfiguration(b =>
               {
               })
               .ConfigureLogging((context, b) =>
               {
                   b.SetMinimumLevel(LogLevel.Debug);
                   b.AddConsole();
               })
               .ConfigureServices(services =>
               {
                   services.AddSingleton<Function1>();
               })
               .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
