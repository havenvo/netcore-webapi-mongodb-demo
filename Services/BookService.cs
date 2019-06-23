using System.Collections.Generic;
using AutoMapper;
using MongoDB.Driver;
using NetCoreApiMongodb.Models;
using NetCoreApiMongodb.Services.Books.Dtos;
using NetCoreApiMongodb.Entities;

namespace NetCoreApiMongodb.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMapper _mapper;

        public BookService(IBookstoreDatabaseSettings settings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Entities.Book>(settings.BooksCollectionName);
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();

        public Book Create(BookDto book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            _books.InsertOne(bookEntity);
            return bookEntity;
        }

        public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Book bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
