using AutoMapper;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Mappers
{
    public class AuthUserProfile : Profile
    {
        public AuthUserProfile()
        {
            CreateMap<LoginAuthUserCommand, AuthUser>().ReverseMap();
            
            CreateMap<RegisterAuthUserCommand, AuthUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
