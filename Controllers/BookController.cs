using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services;
using NetCoreApiMongodb.Services.Authors.Dtos;
using NetCoreApiMongodb.Services.Books.Dtos;

namespace NetCoreApiMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;
        private readonly IMapper _mapper;

        public BookController(BookService bookService, AuthorService authorService, IMapper mapper)
        {
            _bookService = bookService;
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get([FromQuery] string id)
        {
            return Ok(_bookService.Get(id));
        }

        [Route("GetAllBooks")]
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookService.Get();
            var response = books.Select(book => new BookResponseDto {
                Id = book.Id,
                BookName = book.BookName,
                Category = book.Category,
                Author = _mapper.Map<AuthorResponseDto>(_authorService.Get(book.AuthorId))
            });
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] BookDto bookDto)
        {
            return Ok(_bookService.Create(bookDto));
        }
    }
}
