using BookCrudApi.Books.Model;
using BookCrudApi.Books.Repository.interfaces;
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

    }
}
