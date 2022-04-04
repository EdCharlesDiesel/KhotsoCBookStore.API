using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<KhotsoCBookStore.API.Entities.Category, KhotsoCBookStore.API.Dtos.CategoryDto>();
            CreateMap<KhotsoCBookStore.API.Dtos.CategoryForCreateDto, KhotsoCBookStore.API.Entities.Category>();
            CreateMap<KhotsoCBookStore.API.Dtos.CategoryForUpdateDto, KhotsoCBookStore.API.Entities.Category>();
        }
    }
}