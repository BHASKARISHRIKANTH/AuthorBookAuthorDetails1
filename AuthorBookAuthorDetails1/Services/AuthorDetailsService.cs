using AuthorBookAuthorDetails1.Dto;
using AuthorBookAuthorDetails1.Models;
using AuthorBookAuthorDetails1.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookAuthorDetails1.Services
{
    public class AuthorDetailsService:IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _authorDetailsRepository;
        private readonly IMapper _mapper;
        public AuthorDetailsService(IRepository<AuthorDetails> authorDetailsRepository,IMapper mapper)
        {
            _authorDetailsRepository = authorDetailsRepository;
            _mapper = mapper;
        }
        public int AddAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var authorDetails=_mapper.Map<AuthorDetails>(authorDetailsDto);
            _authorDetailsRepository.Add(authorDetails);
            return authorDetails.Id;
        }

        public bool DeleteAuthorDetails(int id)
        {
            var existingauthordetails = _authorDetailsRepository.GetById(id);
            if (existingauthordetails != null)
            {
                _authorDetailsRepository.Delete(existingauthordetails);
                return true;

            }
            return false;
        }


        public List<AuthorDetailsDto> GetAllAuthorDetailss()
        {
            var authorDetails = _authorDetailsRepository.GetAll().Include(a => a.Author).ToList();
            List<AuthorDetailsDto> authorDetailsDtos = _mapper.Map<List<AuthorDetailsDto>>(authorDetails);
            return authorDetailsDtos;

        }

        public AuthorDetailsDto GetAuthorDetails(int id)
        {

            var entityQuery = _authorDetailsRepository.GetAll();

            var authordetails = entityQuery.Where(AuthorDetails => AuthorDetails.Id == id).FirstOrDefault();
            var authorDetailsDto=_mapper.Map<AuthorDetailsDto>(authordetails);
            return authorDetailsDto;
        }

        public bool UpdateAuthorDetails(AuthorDetailsDto authorDetailsDto)
        {
            var existingauthordetails = _authorDetailsRepository.GetAll().FirstOrDefault(a => a.Id == authorDetailsDto.Id);

            if (existingauthordetails != null)
            {
                var updated = _mapper.Map<AuthorDetailsDto>(authorDetailsDto);
                _authorDetailsRepository.Update(existingauthordetails);
               

                return true;
            }
            return false; 
        }

        public AuthorDetailsDto FindAuthorDetailsByAuthorId(int authorId)
        {
            var authorDetails = _authorDetailsRepository.GetAll().Include(ad => ad.Author).FirstOrDefault(ad => ad.Author.Id == authorId);
            if (authorDetails != null)
            {
                return _mapper.Map<AuthorDetailsDto>(authorDetails);
            }
            return null; 
        }




    }
}
