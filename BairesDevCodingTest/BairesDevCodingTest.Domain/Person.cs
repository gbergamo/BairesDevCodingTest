using BairesDevCodingTest.Contracts.Entities;
using System;

namespace BairesDevCodingTest.Domain
{
    public class Person: DomainEntity
    {
        public Int64 PersonId { get { return Id; } set { Id = value; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentRole { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public int? NumberOfRecommendations { get; set; }
        public int? NumberOfConnections { get; set; }
    }
}
