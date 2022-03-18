using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class WishListMappingProfile : Profile
    {
        public WishListMappingProfile()
        {
            CreateMap<Entities.Book, Dtos.BookDto>();
            CreateMap<Dtos.BookForCreateDto,Entities.Book>();
            CreateMap<Dtos.BookForUpdateDto,Entities.Book>();
        }
    }
}