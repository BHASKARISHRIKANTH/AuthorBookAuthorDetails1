using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookAuthorDetails1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var authors = _authorService.GetAllAuthors();
            return Ok(authors);

        }
        [HttpGet("id")]
        public IActionResult GetAuthor(int id)
        {
            
      
                var author = _authorService.GetAuthor(id);
                return Ok(author);
            
            
        }
        [HttpPost]
        public IActionResult Add(AuthorDto authorDto)
        {

            var newId = _authorService.AddAuthor(authorDto);
            return CreatedAtAction(nameof(Add), newId);



        }

        [HttpPut()]
        public IActionResult UpdateAuthor(AuthorDto authorDto)
        {
            var update = _authorService.UpdateAuthor(authorDto);

            if (update)
            {
                return Ok(update);
            }

            return NotFound("Author not found.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var delete = _authorService.GetAuthor(id);
            if (delete != null)
            {
                _authorService.DeleteAuthor(id);
                return Ok(delete);
            }

            return NotFound("Author not found.");
        }
        [HttpGet("Name/{name}")]
        public IActionResult FindAuthorByName(string name)
        {
            var author = _authorService.FindAuthorByName(name);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound($"Author with name '{name}' not found.");

        }

        
        [HttpGet("Author/{bookId}")]
        public IActionResult FindAuthorByBookId(int bookId)
        {
            var author = _authorService.FindAuthorByBookId(bookId);

            if (author != null)
            {
                return Ok(author);
            }

            return NotFound($"No author found for the book with ID {bookId}.");
        }
    }
}
