using AutoMapper;
using BairesDevCodingTest.ApplicationService.InjectionModules;
using BairesDevCodingTest.ApplicationService.Interfaces;
using BairesDevCodingTest.ApplicationService.Mapping;
using BairesDevCodingTest.ApplicationService.Services;
using BairesDevCodingTest.Contracts.Repository;
using BairesDevCodingTest.Infrastructure.InjectionModules;
using BairesDevCodingTest.Repository.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BairesDevCodingTest.WebAPI
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

            IMapper mapper = new MapperConfiguration(cfg => { 
                cfg.AddProfile(new DomainToViewModelMapping()); 
                cfg.AddProfile(new ViewModelToDomainMapping()); 
            }).CreateMapper(); ;
            services.AddSingleton(mapper);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "BairesDev Coding Test API",
                    Version = "v1",
                    Description = "BairesDev Coding Test API.",
                });
            });

            services.Configure<RepositoryConfiguration>(Configuration.GetSection("Repository"));

            new IoCModuleInfrastructure(services);
            new IoCModuleApplicationService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
        }
    }
}
