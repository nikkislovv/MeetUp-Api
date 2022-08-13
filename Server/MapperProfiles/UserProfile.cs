using AutoMapper;
using Entities.DataTransferObjects.UserDTO;
using Entities.Models;

namespace Server.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
