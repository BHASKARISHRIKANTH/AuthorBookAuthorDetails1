using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookAuthorDetails1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _authorDetailsService;
        public AuthorDetailsController(IAuthorDetailsService authorDetailsService)
        {
            _authorDetailsService = authorDetailsService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var authorDetails = _authorDetailsService.GetAllAuthorDetailss();
            return Ok(authorDetails);
            
        }
        [HttpGet("id")]
        public IActionResult GetAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsService.GetAuthorDetails(id);
            return Ok(authorDetails);
        }
        [HttpPost]
        public IActionResult Add(AuthorDetailsDto authorDetailsDto)
        {

            var newId = _authorDetailsService.AddAuthorDetails(authorDetailsDto);
            return CreatedAtAction(nameof(Add), newId);



        }

        [HttpPut()]
        public IActionResult UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var update = _authorDetailsService.UpdateAuthorDetails(authorDetailsDto);

            if (update)
            {
                return Ok(update);
            }

            return NotFound("Author not found.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorDetailas(int id)
        {
            var delete = _authorDetailsService.GetAuthorDetails(id);
            if (delete != null)
            {
                _authorDetailsService.DeleteAuthorDetails(id);
                return Ok(delete);
            }

            return NotFound("Author not found.");
        }

        [HttpGet("AuthorDetails/{authorId}")]
        public IActionResult FindAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetails = _authorDetailsService.FindAuthorDetailsByAuthorId(authorId);

            if (authorDetails != null)
            {
                return Ok(authorDetails);
            }

            return NotFound($"No author details found for AuthorId: {authorId}");
        }




    }
}
