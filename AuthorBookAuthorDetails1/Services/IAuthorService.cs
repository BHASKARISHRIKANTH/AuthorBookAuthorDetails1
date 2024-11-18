using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;

namespace AuthorBookAuthorDetails1.Services
{
    public interface IAuthorService
    {
        public List<AuthorDto> GetAllAuthors();
        public AuthorDto GetAuthor(int id);
        public int AddAuthor(AuthorDto authorDto);
        public bool UpdateAuthor(AuthorDto authorDto);
        public bool DeleteAuthor(int id);
        public AuthorDto FindAuthorByName(string name);
        AuthorDto FindAuthorByBookId(int bookId);



    }
}
