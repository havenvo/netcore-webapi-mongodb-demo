namespace NetCoreApiMongodb.Services.Books.Dtos
{
    public class BookDto
    {
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string AuthorId { get; set; }
    }
}
