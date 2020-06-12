using System;

namespace BairesDevCodingTest.ApplicationService.ViewModels
{
    public class ClientViewModel
    {
        public Int64 PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentRole { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public int? NumberOfRecommendations { get; set; }
        public int? NumberOfConnections { get; set; }
    }
}
