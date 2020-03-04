using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GenericServices.Configuration;
using GenericServices.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.OpenApi.Models;
using MusicTutorAPI.Core.Dtos;
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
            // services.AddDbContext<MusicTutorAPIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MusicTutorAPI.Data")));            
            
            services.AddDbContext<MusicTutorAPIDbContext>(opt =>
               opt.UseInMemoryDatabase("MusicTutorFull"));

            services.GenericServicesSimpleSetup<MusicTutorAPIDbContext>(new GenericServicesConfig
            {
                DtoAccessValidateOnSave = true,     //we use  Dto access for Create/Update
                DirectAccessValidateOnSave = true  //And direct access for Delete                
            }, Assembly.GetAssembly(typeof(CreateInstrumentDto)));   

            // Register the Swagger services
            services.AddSwaggerDocument(config =>
            {
                //config.GeneratorSettings.OperationProcessors.TryGet<ApiVersionProcessor>().IncludedVersions = new[] { "1.0" };
                //config.SwaggerRoute = "v1.0.json";
                config.Title = "Music Tutor V1";                
            });
            
            // services.AddSwaggerGen(options =>
            // {
            //     options.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Tutor", Version = "v1" });
            // });
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
            });

            app.UseOpenApi();
            app.UseSwaggerUi3(c =>
            {
                c.DocumentTitle = "Music Tutor V1";
            });

            // app.UseSwagger();

            // app.UseSwaggerUI(c =>
            // {
            //     c.RoutePrefix = "";
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Tutor V1");
            // });
        }
    }
}
