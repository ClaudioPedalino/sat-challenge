using Sat.Recruitment.Application.Interfaces;
using System;

namespace Sat.Recruitment.Application.Models.Responses
{
    public class GetUserResponse : IQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
