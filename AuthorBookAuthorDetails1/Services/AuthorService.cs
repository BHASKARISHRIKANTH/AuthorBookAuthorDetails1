using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Exceptions;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookAuthorDetails1.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public int AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);

            _authorRepository.Add(author);
            return author.Id;
        }

        public bool DeleteAuthor(int id)
        {
            var existingauthor = _authorRepository.GetById(id);
            if (existingauthor != null)
            {
                _authorRepository.Delete(existingauthor);
                return true;

            }
            return false;
        }


        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAll().Include(a => a.Books).Include(a => a.AuthorDetails).ToList();
            List<AuthorDto> authorDtos = _mapper.Map<List<AuthorDto>>(authors);
            return authorDtos;
        }

        public AuthorDto GetAuthor(int id)
        {

            var entityQuery = _authorRepository.GetAll();


            var author = entityQuery.Where(Author => Author.Id == id).FirstOrDefault();
            if (author == null)
            {
                throw new AuthorNotFoundException("No such author found");
            }
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public bool UpdateAuthor(AuthorDto authorDto)
        {

            var existingauthor = _authorRepository.GetAll().FirstOrDefault(a => a.Id == authorDto.Id);

            if (existingauthor != null)
            {
                var updated = _mapper.Map<AuthorDto>(authorDto);
                _authorRepository.Update(existingauthor);

                return true;
            }
            return false;
        }

        public AuthorDto FindAuthorByName(string name)
        {
            var author = _authorRepository.GetAll()
                .AsEnumerable()
                .FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (author != null)
            {
                return _mapper.Map<AuthorDto>(author);
            }

            return null;
        }

        public AuthorDto FindAuthorByBookId(int bookId)
        {
            var book = _authorRepository.GetAll()
                        .Include(a => a.Books)
                        .FirstOrDefault(a => a.Books.Any(b => b.Id == bookId));

            if (book != null)
            {
                return _mapper.Map<AuthorDto>(book);
            }
            return null;


        }
    }
}
