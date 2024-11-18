using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;

namespace AuthorBookAuthorDetails1.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailsDto> GetAllAuthorDetailss();
        public AuthorDetailsDto GetAuthorDetails(int id);
        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto);
        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto);
        public bool DeleteAuthorDetails(int id);
        public AuthorDetailsDto FindAuthorDetailsByAuthorId(int authorId);
    }
}
