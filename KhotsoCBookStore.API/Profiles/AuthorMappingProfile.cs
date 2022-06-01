using AutoMapper;
using KhotsoCBookStore.API.DTO;
using KhotsoCBookStore.API.Models.Authors;
using KhotsoCBookStore.API.Queries;

namespace KhotsoCBookStore.API.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            //CreateMap<AuthorsListViewModel,AuthorDTO>();
            // CreateMap<Dtos.AuthorForCreateDto,Entities.Author>();
            // CreateMap<Dtos.AuthorForUpdateDto,Entities.Author>();
        }
    }
}