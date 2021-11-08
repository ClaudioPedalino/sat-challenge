using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.Dto;
using Sat.Recruitment.Application.Extensions;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Queries
{
    public record GetAllUserQuery(
        string Name,
        string Email,
        string Address,
        string Phone,
        string UserType,
        decimal? MoneyFrom,
        decimal? MoneyTo,
        bool BypassCache) : PaginableQuery, IRequest<PaginationResponse<GetUserResponse>>, ICacheable
    {
        public static GetAllUserQuery BuildGetAllUserQuery(GetAllUserDto request)
            => new(
                Name: request.Name,
                Email: request.Email,
                Address: request.Address,
                Phone: request.Phone,
                UserType: request.UserType,
                MoneyFrom: request.MoneyFrom,
                MoneyTo: request.MoneyTo,
                BypassCache: request.BypassCache);
        //PageNumber: request.PageNumber > 0 ? request.PageNumber : 1,
        //PageSize: request.PageSize > 0 ? request.PageSize : 15);

        public string CacheKey => $"{GetType().Name}-{Name}-{Email}-{Address}-{Phone}-{UserType}-{MoneyFrom}-{MoneyTo}";
        public TimeSpan? SlidingExpiration { get; set; }
    }


    public class GetUserQueryHandler : IRequestHandler<GetAllUserQuery, PaginationResponse<GetUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<PaginationResponse<GetUserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var usersDb = await _userRepository.GetAll();
            var usersDbFiltered = ApllyFilters(request, usersDb);

            var data = _mapper.Map<List<GetUserResponse>>(
                source: PaginationResponse<GetUserResponse>.Paginate(request, usersDbFiltered ?? usersDb));

            return PaginationResponse<GetUserResponse>.CreatePaginationResult(
                request: request,
                total: usersDb.Count(),
                data: data);
        }

        private static IQueryable<User> ApllyFilters(GetAllUserQuery request, IQueryable<User> usersDb)
            => usersDb
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), x => x.Name.Contains(request.Name))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Email), x => x.Email.Contains(request.Email))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Address), x => x.Address.Contains(request.Address))
                .WhereIf(!string.IsNullOrWhiteSpace(request.Phone), x => x.Phone.Contains(request.Phone))
                //.WhereIf(!string.IsNullOrWhiteSpace(request.Search), x => x.UserType.Contains(request.Search))
                .WhereIf(request.MoneyFrom.HasValue, x => x.Money >= request.MoneyFrom.Value)
                .WhereIf(request.MoneyTo.HasValue, x => x.Money <= request.MoneyTo.Value);
    }
}
