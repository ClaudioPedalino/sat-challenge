using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models;
using Sat.Recruitment.Application.Queries;
using Sat.Recruitment.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Application.Wrappers
{
    public class PaginationResult<TResponse>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TResponse> Data { get; set; }

        public static PaginationResult<TResponse> CreatePaginationResult<TQuery>(TQuery request, int total, List<TResponse> data)
            where TQuery : IPaginable
        {
            var response = new PaginationResult<TResponse>()
            {
                Data = data,
                PageSize = request.PageSize,
                TotalPages = (total / request.PageSize) + 1,
                TotalCount = total
            };
            return response;
        }

        public static IQueryable<TEntity> Paginate<TEntity, TQuery>(TQuery request, IQueryable<TEntity> dataDb)
            //where TEntity : BaseEntity
            where TQuery : IPaginable
        {
            return dataDb.Skip((request.PageNumber - 1) * request.PageSize)
                         .Take(request.PageSize);
        }
    }
}
