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
            var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        s.AddSingleton<Function1>();
    })
    .UseConsoleLifetime()
    .Build();

           

            
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
