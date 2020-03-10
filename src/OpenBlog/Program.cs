using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OpenBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.UseStartup<Startup>();
                webHostBuilder.ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                });
                if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
                    webHostBuilder.UseUrls("https://*:5402", "http://*:5500");
                else
                    webHostBuilder.UseUrls("https://localhost:5402", "http://localhost:5500");
                webHostBuilder.UseKestrel();
            });

            return hostBuilder;
        }
    }
}
