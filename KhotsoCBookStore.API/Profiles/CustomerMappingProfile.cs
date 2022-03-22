using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Entities.Customer, Dtos.CustomerDto>();
            CreateMap<Dtos.CustomerForCreateDto,Entities.Customer>();
            CreateMap<Dtos.CustomerForUpdateDto,Entities.Customer>();
        }
    }
}