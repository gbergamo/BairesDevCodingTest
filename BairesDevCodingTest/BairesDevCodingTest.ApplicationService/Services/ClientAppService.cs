using AutoMapper;
using BairesDevCodingTest.ApplicationService.Interfaces;
using BairesDevCodingTest.ApplicationService.ViewModels;
using BairesDevCodingTest.Contracts.Repository;
using BairesDevCodingTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BairesDevCodingTest.ApplicationService.Services
{
    public class ClientAppService : BaseAppService, IClientAppService
    {
        private readonly IRepository<Person> personRepository;

        public ClientAppService(IRepository<Person> personRepository, IMapper mapper) : base(mapper)
        {
            this.personRepository = personRepository;
        }
        public ClientPositionViewModel GetClientPosition(long id)
        {
            var position = personRepository.All().OrderByDescending(x => x.NumberOfRecommendations).ToList().FindIndex(x => x.PersonId == id) + 1;
            return Mapper.Map<ClientPositionViewModel>(position);
        }

        public IEnumerable<TopClientsViewModel> GetTopClient(int quantity)
        {
            var people = personRepository.All().OrderByDescending(x => x.NumberOfRecommendations).Take(quantity);
            return Mapper.Map<IEnumerable<TopClientsViewModel>>(people);
        }

        public ClientViewModel InsertClient(ClientViewModel client)
        {
            var model = Mapper.Map<Person>(client);
            return Mapper.Map<ClientViewModel>(personRepository.Insert(model));
        }
    }
}
