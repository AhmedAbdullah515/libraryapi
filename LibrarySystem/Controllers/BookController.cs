using AutoMapper;
using LibrarySystem.DTOs.BookDTOs;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;
        public BookController(IUnitWork Unit,IMapper mapper)
        {
            _unit = Unit;
            _mapper = mapper;
        }
        [HttpPost("createBook")]
        public IActionResult Create(CreateBookDTO dto)
        {
            if (_unit.Categoryrepeo.GetById(dto.CategoryId) == null)
            {
                return NotFound();
            }
            var book = _mapper.Map<Book>(dto);
            _unit.Bookrepo.Create(book);
            _unit.Save();
            return Ok("Created");
        }
        [HttpGet("bookfilter")]
        public IActionResult GetAllBooks(string keyword)
        {
            var books = _unit.Bookrepo.GetBooksByKeyWord(keyword);
            var result = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(result);
        }
        [HttpGet("BookByHighestPrice")]
        public IActionResult GetBookByPirce()
        {
            var Book = _unit.Bookrepo.GetBookByHighstPrice();
            var result = _mapper.Map<BookDTO>(Book);
            return Ok(result);
        }
    }
}
