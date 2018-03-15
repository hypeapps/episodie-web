using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EpisodieWeb
{
    public class Program
    {
        // Nazwa użytkownika episodie api
        public static string EPISODIE_API_USERNAME = "YOUR USERNAME";
        // Hasło użytkownika episodie api
        public static string EPISODIE_API_PASSWORD = "YOUR PASSWORD";

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
