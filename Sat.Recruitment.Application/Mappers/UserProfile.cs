using AutoMapper;
using Sat.Recruitment.Application.Commands;
using Sat.Recruitment.Application.Extensions;
using Sat.Recruitment.Application.Models.Responses;
using Sat.Recruitment.Domain.Entities;
using System;

namespace Sat.Recruitment.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Cual es mejor?
            //CreateMap<(CreateUserCommand request, string email), User>()
            //    .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.request.UserType.ToString()))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email))
            //    .ReverseMap();

            CreateMap<Tuple<CreateUserCommand, string, decimal>, User>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Item1.Address))
                .ForMember(dest => dest.Money, opt => opt.MapFrom(src => src.Item3))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item1.Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Item1.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Item2))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.Item1.UserType.ToString()))
                .ReverseMap();

            CreateMap<User, GetUserResponse>().ReverseMap();

            CreateMap<User, GetUserDetailResponse>()
                .ForMember(dest => dest.LastModificationAt, opt => opt.MapFrom(src => src.LastModificationAt.ToDate()))
                .ReverseMap();
        }
    }
}
