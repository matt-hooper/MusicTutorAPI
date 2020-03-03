using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicTutorAPI.Api.Helpers;

namespace MusicTutorAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).SetupDevelopmentDatabase().Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .SetupDevelopmentDatabase();
    }
}
