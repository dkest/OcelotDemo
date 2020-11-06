using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;

namespace OcelotDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context,config) =>
            {
                config
                 .SetBasePath(context.HostingEnvironment.ContentRootPath)
                .AddJsonFile("configuration.json");
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    
                    .UseUrls("http://*:5000/")
                    .UseStartup<Startup>();
                });
    }
}
