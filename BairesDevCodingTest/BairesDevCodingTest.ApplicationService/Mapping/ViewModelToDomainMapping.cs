using AutoMapper;
using BairesDevCodingTest.ApplicationService.ViewModels;
using BairesDevCodingTest.Domain;

namespace BairesDevCodingTest.ApplicationService.Mapping
{
    public class ViewModelToDomainMapping: Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<ClientViewModel, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonId));
        }
    }
}
