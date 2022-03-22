using AutoMapper;

namespace KhotsoCBookStore.API.Profiles
{
    public class PublisherMappingProfile : Profile
    {
        public PublisherMappingProfile()
        {
            CreateMap<Entities.Publisher, Dtos.PublisherDto>();
            CreateMap<Dtos.PublisherForCreateDto,Entities.Publisher>();
            CreateMap<Dtos.PublisherForUpdateDto,Entities.Publisher>();
        }
    }
}