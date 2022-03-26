using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class ProductSubscriptionMappingProfile : Profile
    {
        public ProductSubscriptionMappingProfile()
        {
            CreateMap<Entities.ProductSubscription, Dtos.ProductSubscriptionDto>();
            CreateMap<Dtos.ProductSubscriptionForCreateDto,Entities.ProductSubscription>();
            CreateMap<Dtos.ProductSubscriptionForUpdateDto,Entities.ProductSubscription>();
        }
    }
}