using Sat.Recruitment.Application.Interfaces;
using System;

namespace Sat.Recruitment.Application.Models
{
    public class GetUserDetailResponse : IQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string LastModificationAt { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
    }
}
