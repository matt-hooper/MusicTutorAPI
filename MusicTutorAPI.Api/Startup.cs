using System.Reflection;
using GenericServices.Configuration;
using GenericServices.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicTutorAPI.Api.Controllers.Instruments.Dtos;
using MusicTutorAPI.Data;

namespace MusicTutorAPI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MusicTutorAPIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MusicTutorAPI.Data")));            
            
            // services.AddDbContext<MusicTutorAPIDbContext>(opt =>
            //    opt.UseInMemoryDatabase("MusicTutorFull"));

            services.GenericServicesSimpleSetup<MusicTutorAPIDbContext>(new GenericServicesConfig
            {
                DtoAccessValidateOnSave = true,     //we use  Dto access for Create/Update
                DirectAccessValidateOnSave = true  //And direct access for Delete                
            }, Assembly.GetAssembly(typeof(CreateInstrumentDto)));   

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                config.Title = "Music Tutor V1";                
            });   

            services.AddHealthChecks().AddSqlServer(Configuration.GetConnectionString("Default"));;             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(c =>
            {
                c.DocumentTitle = "Music Tutor V1";
            });
        }
    }
}
