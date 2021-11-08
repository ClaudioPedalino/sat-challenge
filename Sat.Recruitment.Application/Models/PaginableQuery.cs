using Sat.Recruitment.Application.Interfaces;

namespace Sat.Recruitment.Application.Models
{
    public record PaginableQuery : IPaginableQuery
    {
        public PaginableQuery()
        {
            PageNumber = 1;
            PageSize = 15;
        }

        public virtual int PageNumber { get; set; }
        public virtual int PageSize { get; set; }
    }
}
