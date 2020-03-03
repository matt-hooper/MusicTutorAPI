using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MusicTutorAPI.Data;
using MusicTutorAPI.Services.DatabaseCode.Services;

namespace MusicTutorAPI.Api.Helpers
{
    public static class DatabaseStartupHelpers
    {

        public static IWebHost SetupDevelopmentDatabase(this IWebHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = services.GetRequiredService<MusicTutorAPIDbContext>())
                {
                    try
                    {
                        context.DevelopmentEnsureCreated();
                        context.SeedDatabase();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while setting up or seeding the development database.");
                    }
                }
            }

            return webHost;
        }
    }
}