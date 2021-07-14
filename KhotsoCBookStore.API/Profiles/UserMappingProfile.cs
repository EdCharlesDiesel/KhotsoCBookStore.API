using AutoMapper;
using KhotsoCBookStore.API.Authentication;
using KhotsoCBookStore.API.Models;

namespace KhotsoCBookStore.API.Helpers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserMaster, UserMaster>();
            CreateMap<RegisterModel, UserMaster>();
            CreateMap<UpdateModel, UserMaster>();
        }
    }
}