
using AutoMapper;
using Todo.Application.Dtos.Requests;
using Todo.Domain.DomainEntities;

namespace Todo.Application.mapper
{
    public class UserMapping : Profile
    {
        public UserMapping() { 
        CreateMap<CreateUserDto, UserDomain>().ForMember(dest => dest.PasswordHash, option => option.MapFrom(src => src.Password));
        }
    }
}
