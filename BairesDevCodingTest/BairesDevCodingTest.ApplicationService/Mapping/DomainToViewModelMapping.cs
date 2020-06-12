using AutoMapper;
using BairesDevCodingTest.ApplicationService.ViewModels;
using BairesDevCodingTest.Domain;

namespace BairesDevCodingTest.ApplicationService.Mapping
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Person, ClientViewModel>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Person, TopClientsViewModel>()
                .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.Id));

            CreateMap<int, ClientPositionViewModel>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src));
        }

    }
}
