using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Entities.Book, Dtos.BookDto>();
            CreateMap<Dtos.BookForCreateDto,Entities.Book>();
            CreateMap<Dtos.BookForUpdateDto,Entities.Book>();
        }
    }
}