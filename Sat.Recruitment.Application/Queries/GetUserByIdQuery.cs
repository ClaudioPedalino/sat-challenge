using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Queries
{
    public record GetUserByIdQuery(Guid Id, bool BypassCache) : IRequest<GetUserDetailResponse>, ICacheable
    {
        public string CacheKey => $"{GetType().Name}-{Id}";
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDetailResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            => _mapper.Map<GetUserDetailResponse>(
                await _userRepository.GetById(request.Id));
    }
}
