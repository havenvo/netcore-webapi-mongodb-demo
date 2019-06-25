using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services.Authors.Dtos;

namespace NetCoreApiMongodb.Services.Books.Dtos
{
    public class BookResponseDto : Book
    {
        public AuthorResponseDto Author { get; set; }
    }
}
