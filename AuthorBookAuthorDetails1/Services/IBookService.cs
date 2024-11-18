using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;

namespace AuthorBookAuthorDetails1.Services
{
    public interface IBookService
    {
        public List<BookDto> GetAllBooks();
        public BookDto GetBook(int id);
        public int AddBook(BookDto bookDto);
        public bool UpdateBook(BookDto bookDto);
        public bool DeleteBook(int id);
        public List<BookDto> FindBooksByAuthorId(int authorId);
    }
}
