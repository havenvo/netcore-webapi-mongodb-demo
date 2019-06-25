using System.Collections.Generic;
using AutoMapper;
using MongoDB.Driver;
using NetCoreApiMongodb.Models;
using NetCoreApiMongodb.Services.Books.Dtos;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services.Authors.Dtos;

namespace NetCoreApiMongodb.Services
{
    public class AuthorService
    {
        private readonly IMongoCollection<Author> _authors;
        private readonly IMapper _mapper;

        public AuthorService(IBookstoreDatabaseSettings settings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _authors = database.GetCollection<Entities.Author>("Authors");
        }

        public List<Author> Get() =>
            _authors.Find(book => true).ToList();

        public Author Get(string id) =>
            _authors.Find<Author>(author => author.Id == id).FirstOrDefault();

        public Author Create(AuthorDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _authors.InsertOne(authorEntity);
            
            return authorEntity;
        }

        public void Update(string id, Author authorIn) =>
            _authors.ReplaceOne(author => author.Id == id, authorIn);

        public void Remove(Author authorIn) =>
            _authors.DeleteOne(author => author.Id == authorIn.Id);

        public void Remove(string id) =>
            _authors.DeleteOne(author => author.Id == id);
    }
}
