using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiMongodb.Entities;
using NetCoreApiMongodb.Services;
using NetCoreApiMongodb.Services.Authors.Dtos;
using NetCoreApiMongodb.Services.Books.Dtos;

namespace NetCoreApiMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;

        public AuthorController(BookService bookService, AuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<Author>))]
        public ActionResult<IEnumerable<Author>> Get([FromQuery] string id)
        {

            return Ok(_authorService.Get(id));
        }

        [Route("GetAllAuthors")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<Author>))]
        public ActionResult<IEnumerable<Author>> GetAll()
        {

            return Ok(_authorService.Get());
        }

        [HttpPost]
        public ActionResult<Author> Create([FromBody] AuthorDto authorDto) 
        {
            return Ok(_authorService.Create(authorDto));
        }
    }
}
