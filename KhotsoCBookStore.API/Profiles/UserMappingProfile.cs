using AutoMapper;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Dtos;

namespace KhotsoCBookStore.API.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserMaster, UserMaster>();

            CreateMap<RegisterDto, UserMaster>();
            
            CreateMap<UpdateDto, UserMaster>();
        }
    }
}