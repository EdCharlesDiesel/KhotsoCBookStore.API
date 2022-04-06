using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Authentication.UserMaster, Dtos.LoginDto>();
            CreateMap<Dtos.RegisterDto,Authentication.UserMaster>();
           // CreateMap<Dtos.LoginDto,Authentication.UserMaster>();
        }
    }
}