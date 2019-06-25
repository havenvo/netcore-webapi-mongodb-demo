using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services.Authors.Dtos;

namespace NetCoreApiMongodb.Services.Books.Dtos
{
    public class BookResponseDto
    {
        public string Id { get; set; }
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
        
        public AuthorResponseDto Author { get; set; }
    }
}
