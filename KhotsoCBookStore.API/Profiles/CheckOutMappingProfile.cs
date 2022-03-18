using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class CheckOutMappingProfile : Profile
    {
        public CheckOutMappingProfile()
        {
            CreateMap<Entities.Order, Dtos.OrderDto>();
            CreateMap<Dtos.OrderForCreateDto,Entities.Order>();
            CreateMap<Dtos.OrderForUpdateDto,Entities.Order>();
        }
    }
}