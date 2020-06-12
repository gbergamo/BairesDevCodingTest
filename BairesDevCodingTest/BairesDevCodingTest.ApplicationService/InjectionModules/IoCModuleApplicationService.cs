using BairesDevCodingTest.ApplicationService.Interfaces;
using BairesDevCodingTest.ApplicationService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BairesDevCodingTest.ApplicationService.InjectionModules
{
    public class IoCModuleApplicationService
    {
        public IoCModuleApplicationService(IServiceCollection services)
        {
            services.AddTransient<IClientAppService, ClientAppService>();
        }
    }
}
