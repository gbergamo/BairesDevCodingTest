using BairesDevCodingTest.ApplicationService.Interfaces;
using BairesDevCodingTest.ApplicationService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BairesDevCodingTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientAppService clientAppService;

        public ClientsController(IClientAppService clientAppService)
        {
            this.clientAppService = clientAppService;
        }

        [HttpGet("TopClients/{quantity}")]
        public IEnumerable<TopClientsViewModel> TopClients([FromRoute]int quantity)
        {
            return clientAppService.GetTopClient(quantity);
        }

        [HttpGet("ClientPosition/{id}")]
        public ClientPositionViewModel ClientPosition([FromRoute]Int64 id)
        {
            return clientAppService.GetClientPosition(id);
        }

        [HttpPost]
        public ClientViewModel InserClient([FromBody]ClientViewModel clientViewModel)
        {
            return clientAppService.InsertClient(clientViewModel);
        }
    }
}