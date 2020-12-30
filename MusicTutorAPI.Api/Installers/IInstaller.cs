using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MusicTutorAPI.Api.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);  
    } 
}