using BairesDevCodingTest.ApplicationService.ViewModels;
using System;
using System.Collections.Generic;

namespace BairesDevCodingTest.ApplicationService.Interfaces
{
    public interface IClientAppService
    {
        IEnumerable<TopClientsViewModel> GetTopClient(int quantity);
        ClientPositionViewModel GetClientPosition(Int64 id);
        ClientViewModel InsertClient(ClientViewModel client);
    }
}
