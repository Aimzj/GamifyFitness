using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamifyFitness.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GamifyFitness
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            CheckLogin(host);
            host.Run();
            
        }

        public static void CheckLogin(IWebHost host)
        {
            var Scopefactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = Scopefactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Seeder>();
                seeder.Seed(); 
            }
                
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfig)
                .UseStartup<Startup>();

        private static void SetupConfig(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true);
        }
    }
}
