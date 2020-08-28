using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Evolution
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            Console.OpenStandardOutput();
            Services.EvolutionSimulator simulator = new Services.EvolutionSimulator();
            await simulator.Start();

            //while (simulator.Tick <= 10)
            while(simulator.Done == false)
            {

            }

            Console.WriteLine("done");
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
