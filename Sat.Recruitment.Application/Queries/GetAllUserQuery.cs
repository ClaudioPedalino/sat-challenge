using AutoMapper;
using MediatR;
using Sat.Recruitment.Application.Interfaces;
using Sat.Recruitment.Application.Models;
using Sat.Recruitment.Application.Wrappers;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Queries
{
    public class GetAllUserQuery : Paginable, IRequest<PaginationResult<GetUserResponse>>
    {
        public string Search { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetAllUserQuery, PaginationResult<GetUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<PaginationResult<GetUserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var usersDb = await _userRepository.GetAll();
            
            var result = _mapper.Map<List<GetUserResponse>>(
                source: PaginationResult<GetUserResponse>.Paginate(request, usersDb));
            
            return PaginationResult<GetUserResponse>.CreatePaginationResult(
                request: request,
                total: usersDb.Count(),
                data: result);
        }
    }
}
