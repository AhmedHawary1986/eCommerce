using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UserService.Domain.Entities;
using UserService.Domain.DTO;

namespace UserService.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile() 
        { 
           CreateMap<ApplicationUser,AuthenticationResponse>()
           .ForMember(dest=>dest.UserID,opt=>opt.MapFrom(src=> src.UserID))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
           .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
           .ForMember(dest => dest.Sucess, opt => opt.Ignore())
           .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}
