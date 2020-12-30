using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MusicTutorAPI.Api.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.Title = "Music Tutor V1";
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Description = "https://github.com/matt-hooper/MusicTutorAPI";
                };
            });


        }
    }
}