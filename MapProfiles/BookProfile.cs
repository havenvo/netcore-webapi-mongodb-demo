using AutoMapper;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services.Books.Dtos;

namespace NetCoreApiMongodb.MapProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>();
        }
    }
}
