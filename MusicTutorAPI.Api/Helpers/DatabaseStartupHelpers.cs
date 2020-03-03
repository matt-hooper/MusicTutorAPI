using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicTutorAPI.Data;
using MusicTutorAPI.Services.DatabaseCode.Services;

namespace MusicTutorAPI.Api.Helpers
{
    public static class DatabaseStartupHelpers
    {

        public static IHost SetupDevelopmentDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
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

            return host;
        }
    }
}