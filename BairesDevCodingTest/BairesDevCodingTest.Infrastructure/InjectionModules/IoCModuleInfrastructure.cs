using BairesDevCodingTest.Contracts.Repository;
using BairesDevCodingTest.Repository.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace BairesDevCodingTest.Infrastructure.InjectionModules
{
    public class IoCModuleInfrastructure
    {
        public IoCModuleInfrastructure(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(FileRepository<>));
        }
    }
}
