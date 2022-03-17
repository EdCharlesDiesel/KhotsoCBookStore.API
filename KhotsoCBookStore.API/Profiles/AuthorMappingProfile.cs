using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Entities.Author, Dtos.AuthorDto>();
            CreateMap<Dtos.AuthorForCreateDto,Entities.Author>();
            CreateMap<Dtos.AuthorForUpdateDto,Entities.Author>();
        }
    }
}