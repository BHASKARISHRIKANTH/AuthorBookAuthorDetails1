using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookAuthorDetails1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult Get()
        {
           
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("id")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Add(BookDto bookDto)
        {
           
            var newId = _bookService.AddBook(bookDto);
            return CreatedAtAction(nameof(Add), newId);



        }

        [HttpPut()]
        public IActionResult UpdateBook(BookDto bookDto)
        {
            var update = _bookService.UpdateBook(bookDto);

            if (update!=null)
            {
                return Ok(update);
            }

            return NotFound("Author not found.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var delete = _bookService.GetBook(id);
            if (delete != null)
            {
                _bookService.DeleteBook(id);
                return Ok(delete);
            }

            return NotFound("Author not found.");
        }

        [HttpGet("Book/{authorId}")]
        public IActionResult FindBooksByAuthorId(int authorId)
        {
            var books = _bookService.FindBooksByAuthorId(authorId);

            if (books != null && books.Count > 0)
            {
                return Ok(books); 
            }

            return NotFound($"No books found for author with ID {authorId}."); 
        }
    }
}
