using BookCrudApi.Books.Model;
using BookCrudApi.Books.Repository.interfaces;
using BookCrudApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookCrudApi.Books.Controller
{
    [ApiController]
    [Route("book/api/v1")]
    public class BookController:ControllerBase
    {
        private ILogger _logger;
        private IBookRepository _bookRepository;

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books=await _bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Book>>>GetById(int id)
        {
            var books=await _bookRepository.GetByIdAsync(id);
            return Ok(books);
        }

        [HttpGet("title")]
        public async Task<ActionResult<IEnumerable<Book>>>GetByTitle(string title)
        {
            var books=await _bookRepository.GetByTitleAsync(title);
            return Ok(books);
        }

        [HttpPost("createBook")]
        public async Task<ActionResult<Book>>CreateBook([FromBody] CreateBookRequest request)
        {
            var books = await _bookRepository.CreateBook(request);

            return Ok(books);
        }

        [HttpPut("updateBook")]
        public async Task<ActionResult<Book>>UpdateBook([FromQuery] int id, UpdateBookRequest request)
        {
            var book = await _bookRepository.UpdateBook(id, request);

            return Ok(book);
        }

        [HttpDelete("/deleteById")]
        public async Task<ActionResult<Book>> DeleteProduct([FromQuery] int id)
        {
            var book = await _bookRepository.DeleteBookById(id);

            return Ok(book);
        }

    }
}
