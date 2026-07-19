using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookRepository.AddBook(book);

            return Ok("Book added successfully.");

        }

    }
}
