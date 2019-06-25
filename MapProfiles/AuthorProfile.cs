using AutoMapper;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services.Authors.Dtos;

namespace NetCoreApiMongodb.MapProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<Author, AuthorResponseDto>();
        }
    }
}
