using Sat.Recruitment.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Application.Wrappers
{
    public class PaginationResponse<TResponse>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TResponse> Data { get; set; }

        public static PaginationResponse<TResponse> CreatePaginationResult<TQuery>(TQuery request, int total, List<TResponse> data)
            where TQuery : IPaginable => new()
            {
                Data = data,
                PageSize = request.PageSize,
                TotalPages = (total / request.PageSize) + 1,
                TotalCount = total
            };

        public static IQueryable<TEntity> Paginate<TEntity, TQuery>(TQuery request, IQueryable<TEntity> dataDb)
            //where TEntity : BaseEntity
            where TQuery : IPaginable =>
            dataDb.Skip((request.PageNumber - 1) * request.PageSize)
                  .Take(request.PageSize);
    }
}
