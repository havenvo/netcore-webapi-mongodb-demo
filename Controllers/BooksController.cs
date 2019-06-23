using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services;
using NetCoreApiMongodb.Services.Books.Dtos;

namespace NetCoreApiMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable< Book>> Get([FromQuery] string id)
        {
            return id == null ? _bookService.Get() : new List<Book>() { _bookService.Get(id) };
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] BookDto bookDto)
        {
            return _bookService.Create(bookDto);
        }
    }
}
