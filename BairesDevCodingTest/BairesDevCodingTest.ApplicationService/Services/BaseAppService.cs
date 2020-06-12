using AutoMapper;

namespace BairesDevCodingTest.ApplicationService.Services
{
    public class BaseAppService
    {
        public IMapper Mapper { get; private set; }

        public BaseAppService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
