using System.Reflection;
using GenericServices.Configuration;
using GenericServices.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicTutorAPI.Api.Controllers.Instruments.Dtos;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Api.Installers
{
    public class DbAndGenericServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicTutorAPIDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MusicTutorAPI.Data")));

            // services.AddDbContext<MusicTutorAPIDbContext>(opt =>
            //    opt.UseInMemoryDatabase("MusicTutorFull"));            

            services.GenericServicesSimpleSetup<MusicTutorAPIDbContext>(new GenericServicesConfig
            {
                DtoAccessValidateOnSave = true,     //we use  Dto access for Create/Update
                DirectAccessValidateOnSave = true  //And direct access for Delete                
            }, Assembly.GetAssembly(typeof(CreateInstrumentDto)));

            services.AddHealthChecks().AddDbContextCheck<MusicTutorAPIDbContext>();  
        }
    }
}