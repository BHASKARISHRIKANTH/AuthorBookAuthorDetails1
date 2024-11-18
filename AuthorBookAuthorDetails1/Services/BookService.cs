using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookAuthorDetails1.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public int AddBook(BookDto bookDto)
        {
            var book=_mapper.Map<Book>(bookDto);

            _bookRepository.Add(book);
            return book.Id;
            
        }

        public bool DeleteBook(int id)
        {
            var existingbook = _bookRepository.GetById(id);
            if (existingbook != null)
            {
                _bookRepository.Delete(existingbook);
                return true;

            }
            return false;
        }

        public List<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll().Include(a => a.Author).ToList();
            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public BookDto GetBook(int id)
        {
            var entityQuery = _bookRepository.GetAll();

            var book = entityQuery.Where(Book => Book.Id == id).FirstOrDefault();
            var bookDto= _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public bool UpdateBook(BookDto bookDto)
        {
            var existingbook = _bookRepository.GetAll().FirstOrDefault(a=>a.Id == bookDto.Id);

            if (existingbook != null)
            {
                var updated=_mapper.Map<BookDto>(bookDto);
                _bookRepository.Update(existingbook);

                return true;
            }
            return false;
        }

        public List<BookDto> FindBooksByAuthorId(int authorId)
        {
            var books = _bookRepository.GetAll().Include(b => b.Author).Where(b => b.AuthorId == authorId).ToList();
            if (books != null && books.Count > 0)
            {
                return _mapper.Map<List<BookDto>>(books);
            }
            return new List<BookDto>(); 
        }

       

       




    }
}
