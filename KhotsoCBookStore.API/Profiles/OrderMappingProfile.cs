using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Entities.Order, Dtos.OrderDto>();
            CreateMap<Dtos.OrderForCreateDto,Entities.Order>();
            CreateMap<Dtos.OrderForUpdateDto,Entities.Order>();
        }
    }
}